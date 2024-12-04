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
using BikerStriker.Util;
using BikerStriker.Layers.BLL;
using System.Windows;

namespace BikerStriker.Layers.Reports
{
    public class GenerarFacturaPDF
    {
        public byte[] ObtenerPDF(Factura factura)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            ImageConverter imageConverter = new ImageConverter();

            BLLTienda bllTienda = new BLLTienda();
            Tienda tienda = bllTienda.GetAllTienda()[0];

            double IVA = tienda.ImpuestoVenta / 100;

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
                    page.ContinuousSize(PageSizes.A4.Width);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header().Row(x =>
                    {
                        x.RelativeItem().AlignMiddle().Text($"Factura #{factura.Id}").SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);
                        x.AutoItem().Width(120).Image((Byte[])imageConverter.ConvertTo(global::BikerStriker.Properties.Resources.Logo_whiterounded, typeof(Byte[])));
                    });

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(20);
                            x.Item().Text($"Cliente: {factura.Cliente}").SemiBold().FontSize(16);
                            x.Item().Row(y =>
                            {
                                y.RelativeItem().AlignTop().Text($"Tarjeta: \n{factura.Tarjeta.ToString()}");
                                y.AutoItem().Text($"Precio Total\n₡ {factura.TotalColones.ToString("#,##0.00")}\n$ {factura.TotalDolares.ToString("#,##0.00")}\nImpuesto de Venta\n₡ {(factura.TotalColones * IVA).ToString("#,##0.00")}\n$ {(factura.TotalDolares * IVA).ToString("#,##0.00")}").AlignRight();
                            });
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
                                    header.Cell().Element(HeaderCellStyle).AlignCenter().Text("Nombre");
                                    header.Cell().Element(HeaderCellStyle).AlignCenter().Text("Categoría");
                                    header.Cell().Element(HeaderCellStyle).AlignRight().Text("Colones");
                                    header.Cell().Element(HeaderCellStyle).AlignRight().Text("Dolares");
                                    header.Cell().Element(HeaderCellStyle).AlignCenter().Text("Cantidad");
                                });

                                foreach (FacturaDetalle item in factura.FacturaDetalle)
                                {
                                    table.Cell().Element(RowCellStyle).Text(factura.FacturaDetalle.IndexOf(item) + 1);
                                    table.Cell().Element(RowCellStyle).Text(item.Producto.Nombre);
                                    table.Cell().Element(RowCellStyle).Text(item.Producto.Categoria);
                                    table.Cell().Element(RowCellStyle).AlignRight().Text($"₡ {item.Producto.Precio.ToString("#,##0.00")}");
                                    table.Cell().Element(RowCellStyle).AlignRight().Text($"$ {item.Producto.Dolarizado.ToString("#,##0.00")}");
                                    table.Cell().Element(RowCellStyle).AlignCenter().Text($"#{item.Cantidad.ToString()}");
                                }
                            });
                            double TotalColones = factura.FacturaDetalle.Sum(p => (p.Producto.Precio * p.Cantidad));
                            double TotalDolares = factura.FacturaDetalle.Sum(p => (p.Producto.Dolarizado * p.Cantidad));
                            x.Item().PaddingRight(5).AlignRight().Text($"Total: ₡ {TotalColones.ToString("#,##0.00")}" +
                                $"\n$ {TotalDolares.ToString("#,##0.00")}").SemiBold();
                        });

                    page.Footer().AlignRight().Column(x =>
                    {
                        if(factura.OrdenTrabajo != null)
                        {
                            x.Item().Width(100).Image(ImageSerializer.SerializeImageToString(factura.OrdenTrabajo.Firma));
                        }
                        x.Item().Text(factura.Cliente.Identificacion + "\n");
                        x.Item().Text(y =>
                        {
                            y.Span("Pagína ");
                            y.CurrentPageNumber();
                        });
                    });
                });
                if (factura.OrdenTrabajo != null)
                {
                    container.Page(page =>
                    {
                        page.ContinuousSize(PageSizes.A4.Width);
                        page.Margin(2, Unit.Centimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(12));

                        page.Header().Row(x =>
                        {
                            x.RelativeItem().AlignMiddle().Text($"Orden de trabajo #{factura.OrdenTrabajo.Id}").SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);
                            x.AutoItem().Width(120).Image((Byte[])imageConverter.ConvertTo(global::BikerStriker.Properties.Resources.Logo_whiterounded, typeof(Byte[])));
                        });

                        page.Content()
                            .PaddingVertical(1, Unit.Centimetre)
                            .Column(x =>
                            {
                                x.Spacing(20);
                                x.Item().Text($"Cliente: {factura.Cliente}").SemiBold().FontSize(16);
                                x.Item().Row(y =>
                                {
                                    y.RelativeItem().AlignMiddle().Text($"Modelo de Bicicleta: {factura.OrdenTrabajo.Bicicleta.Modelo}" +
                                                        $"\nNumero de serie: {factura.OrdenTrabajo.Bicicleta.NumeroSerie}" +
                                                        $"\nMarca: {factura.OrdenTrabajo.Bicicleta.Modelo.Marca}");
                                    y.AutoItem().Background(ColorTranslator.ToHtml(factura.OrdenTrabajo.Bicicleta.Color)).Width(120).Padding(5).Image(ImageSerializer.SerializeImageToString(factura.OrdenTrabajo.Bicicleta.Modelo.Marca.Logo));
                                });
                                x.Item().Text($"" +
                                    $"\nFecha de Inicio: {factura.OrdenTrabajo.FechaInicio.ToShortDateString()}." +
                                    $"\nFecha de Finalización: {factura.OrdenTrabajo.FechaFinalizacion.ToShortDateString()}");
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

                                    foreach (OrdenDetalle item in factura.OrdenTrabajo.OrdenDetalle)
                                    {
                                        table.Cell().Element(RowCellStyle).Text(factura.OrdenTrabajo.OrdenDetalle.IndexOf(item) + 1);
                                        table.Cell().Element(RowCellStyle).Text(item.Servicio.Codigo);
                                        table.Cell().Element(RowCellStyle).Text(item.Servicio.Nombre);
                                        table.Cell().Element(RowCellStyle).Text(item.Servicio.Categoria);
                                        table.Cell().Element(RowCellStyle).AlignRight().Text($"₡ {item.Servicio.Precio.ToString("#,##0.00")}");
                                        table.Cell().Element(RowCellStyle).AlignRight().Text($"$ {item.Servicio.Dolarizado.ToString("#,##0.00")}");
                                    }
                                });
                                double TotalColones = factura.OrdenTrabajo.OrdenDetalle.Sum(p => p.Servicio.Precio);
                                double TotalDolares = factura.OrdenTrabajo.OrdenDetalle.Sum(p => p.Servicio.Dolarizado);
                                x.Item().PaddingRight(5).AlignRight().Text($"Total: ₡ {TotalColones.ToString("#,##0.00")}" +
                                    $"\n$ {TotalDolares.ToString("#,##0.00")}").SemiBold();
                            });

                        page.Footer().Row(w =>
                        {
                            w.AutoItem().AlignBottom().Width(100).Image(ImageSerializer.SerializeImageToString(QRCodeGeneratorUtility.GenerateQRCodeFromInteger(factura.OrdenTrabajo.Id)));
                            w.RelativeItem().AlignRight().Column(x =>
                            {
                                x.Item().Width(100).Image(ImageSerializer.SerializeImageToString(factura.OrdenTrabajo.Firma));
                                x.Item().Text(factura.Cliente.Identificacion + "\n");
                                x.Item().Text(y =>
                                {
                                    y.Span("Pagína ");
                                    y.CurrentPageNumber();
                                });
                            });
                        });
                    });
                }
            })
        .GeneratePdf();
        }
    }
}
