using QuestPDF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using BikerStriker.Layers.Entities;
using System.Drawing;
using System.Reflection;
using System.Data.Common;
using BikerStriker.Tools;

namespace BikerStriker.Layers.Reports
{
    public class GenerarOrdenTrabajoPDF
    {
        public byte[] ObtenerPDF(OrdenTrabajo ordenTrabajo)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            ImageConverter imageConverter = new ImageConverter();

            IContainer HeaderCellStyle(IContainer container)
            {
                return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
            }
            IContainer RowCellStyle(IContainer container)
            {
                return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
            }

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    //page.ContinuousSize(PageSizes.A4.Width);
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header().Row(x =>
                    {
                        x.RelativeItem().AlignMiddle().Text($"Orden de trabajo #{ordenTrabajo.Id}").SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);
                        x.AutoItem().Width(120).Image((Byte[])imageConverter.ConvertTo(global::BikerStriker.Properties.Resources.Logo_whiterounded, typeof(Byte[])));
                    });

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(20);
                            x.Item().Text($"Cliente: {ordenTrabajo.Cliente}").SemiBold().FontSize(16);
                            x.Item().Row(y =>
                            {
                                y.RelativeItem().AlignMiddle().Text($"Modelo de Bicicleta: {ordenTrabajo.Bicicleta.Modelo}" +
                                                    $"\nNumero de serie: {ordenTrabajo.Bicicleta.NumeroSerie}" +
                                                    $"\nMarca: {ordenTrabajo.Bicicleta.Modelo.Marca}");
                                y.AutoItem().Background(ColorTranslator.ToHtml(ordenTrabajo.Bicicleta.Color)).Width(120).Padding(5).Image(ImageSerializer.SerializeImageToString(ordenTrabajo.Bicicleta.Modelo.Marca.Logo));
                            });
                            x.Item().Text($"" +
                                $"\nFecha de Inicio: {ordenTrabajo.FechaInicio.ToShortDateString()}." +
                                $"\nFecha de Finalización: {ordenTrabajo.FechaFinalizacion.ToShortDateString()}");
                            x.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(25);
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Element(HeaderCellStyle).Text("#");
                                    header.Cell().Element(HeaderCellStyle).Text("Código");
                                    header.Cell().Element(HeaderCellStyle).AlignCenter().Text("Nombre");
                                    header.Cell().Element(HeaderCellStyle).AlignCenter().Text("Categoría");
                                    header.Cell().Element(HeaderCellStyle).AlignRight().Text("Colones");
                                    header.Cell().Element(HeaderCellStyle).AlignRight().Text("Dolares");
                                });

                                foreach (OrdenDetalle item in ordenTrabajo.OrdenDetalle)
                                {
                                    table.Cell().Element(RowCellStyle).Text(ordenTrabajo.OrdenDetalle.IndexOf(item) + 1);
                                    table.Cell().Element(RowCellStyle).Text(item.Servicio.Codigo);
                                    table.Cell().Element(RowCellStyle).Text(item.Servicio.Nombre);
                                    table.Cell().Element(RowCellStyle).Text(item.Servicio.Categoria);
                                    table.Cell().Element(RowCellStyle).AlignRight().Text($"₡ {item.Servicio.Precio.ToString("#,##0.00")}");
                                    table.Cell().Element(RowCellStyle).AlignRight().Text($"$ {item.Servicio.Dolarizado.ToString("#,##0.00")}");
                                }
                            });
                            double TotalColones = ordenTrabajo.OrdenDetalle.Sum(p => p.Servicio.Precio);
                            double TotalDolares = ordenTrabajo.OrdenDetalle.Sum(p => p.Servicio.Dolarizado);
                            x.Item().PaddingRight(5).AlignRight().Text($"Total: ₡ {TotalColones.ToString("#,##0.00")}" +
                                $"\n$ {TotalDolares.ToString("#,##0.00")}").SemiBold();
                        });

                    page.Footer()
                        .AlignRight()
                        .Text(x =>
                        {
                            x.Span("Pagína ");
                            x.CurrentPageNumber();
                        });
                });
                container.Page(page =>
                {
                    page.ContinuousSize(PageSizes.A4.Width);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header().Row(x =>
                    {
                        x.RelativeItem().AlignMiddle().Text($"Orden de trabajo #{ordenTrabajo.Id}").SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);
                        x.AutoItem().Width(120).Image((Byte[])imageConverter.ConvertTo(global::BikerStriker.Properties.Resources.Logo_whiterounded, typeof(Byte[])));
                    });

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(20);
                            x.Item().Text($"Fotografías").SemiBold().FontSize(16);

                            List<OrdenFoto> ordenFotos = ordenTrabajo.OrdenFoto;

                            for (int i = 0; i < Math.Floor((double) ordenFotos.Count/2); i++)
                            {
                                x.Item().Row(y =>
                                {
                                    y.AutoItem().Width(240).Image(ImageSerializer.SerializeImageToString(ordenFotos[i*2].Foto));
                                    y.AutoItem().Width(240).Image(ImageSerializer.SerializeImageToString(ordenFotos[i*2+1].Foto));
                                });
                            }
                            x.Item().Row(y =>
                            {
                                if (ordenFotos.Count % 2 == 1)
                                {
                                    y.AutoItem().Width(240).Image(ImageSerializer.SerializeImageToString(ordenFotos[ordenFotos.Count - 1].Foto));
                                }
                            });
                        });

                    page.Footer()
                        .AlignRight()
                        .Text(x =>
                        {
                            x.Span("Pagína ");
                            x.CurrentPageNumber();
                        });
                });
            })
        .GeneratePdf();
        }
    }
}
