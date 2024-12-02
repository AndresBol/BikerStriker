using System;


namespace BikerStriker.Patrones
{
    internal class GraveyardFacade
    {
        /*public List<ServicioAdicional> Servicios {  get; set; }
        public short TamanoNicho {  get; set; }
        public Nichos TipoNicho {  get; set; }
        public IUbicacion Ubicacion { get; set; }

        public double CalcularTotal()
        {
            double costoBase = 0, subtotal = 0, porcentaje = 0, total = 0;

            switch (TipoNicho)
            {
                case Nichos.Pequeño: costoBase += 1500; break;
                case Nichos.Mediano: costoBase += 2500; break;
                case Nichos.Grande: costoBase += 4000; break;
            }

            costoBase += Ubicacion.CalcularCosto(TamanoNicho);

            subtotal = costoBase * Math.Pow((TamanoNicho / 5.0), 1.2);

            foreach(ServicioAdicional servicio in Servicios)
            {
                porcentaje += servicio.CostoPorcentaje() / 100;
            }

            total = subtotal + subtotal * porcentaje;

            return total;
        }

        private void OrdenarServicios()
        {
            for (int i = 0; i < Servicios.Count-1; i++)
            {
                if(Servicios[i].Descripcion[0] > Servicios[i+1].Descripcion[0])
                {
                    ServicioAdicional servicioCambio = Servicios[i];
                    Servicios[i] = Servicios[i + 1];
                    Servicios[i + 1] = servicioCambio;
                }
            }
        }


        public void ExportarXML(string ruta)
        {

            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.LoadXml("<GraveyardManagement></GraveyardManagement>");
            xmlDoc.DocumentElement.SetAttribute("Total", CalcularTotal().ToString("#,##0.00"));

            XmlElement nUbicacion = xmlDoc.CreateElement("Ubicacion");
            nUbicacion.InnerText = Ubicacion.Name;

            XmlElement nNicho = xmlDoc.CreateElement("Nicho");
            nNicho.SetAttribute("Tamaño", TamanoNicho.ToString());
            XmlElement nTipoNicho = xmlDoc.CreateElement("Tipo");
            nTipoNicho.InnerText = TipoNicho.ToString();
            nNicho.AppendChild(nTipoNicho);

            XmlElement nServiciosAdicionales = xmlDoc.CreateElement("ServiciosAdicionales");

            OrdenarServicios();
            foreach (ServicioAdicional servicio in Servicios)
            {
                XmlElement nservicio = xmlDoc.CreateElement("Servicio");
                nservicio.SetAttribute("Porcentaje", servicio.CostoPorcentaje().ToString());

                XmlElement nDescripcionservicio = xmlDoc.CreateElement("Descripcion");
                nDescripcionservicio.InnerText = servicio.Descripcion;

                nservicio.AppendChild(nDescripcionservicio);

                nServiciosAdicionales.AppendChild(nservicio);
            }

            xmlDoc.DocumentElement.AppendChild(nUbicacion);
            xmlDoc.DocumentElement.AppendChild(nNicho);
            xmlDoc.DocumentElement.AppendChild(nServiciosAdicionales);

            xmlDoc.Save(ruta);

        }

        public void TransformarXMLToHTML(string rutaXML)
        {
            string rutaHtml = Application.StartupPath + "\\Graveyard.html";
            string rutaXslt = Application.StartupPath + "\\Xslt\\Graveyard.xslt";
            // Transformación del XMl utilizando XSLT
            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            // Carga en memoria la lectura xslt
            myXslTrans.Load(rutaXslt);
            // Transforma el archivo xml aun archivo HTML
            myXslTrans.Transform(rutaXML, rutaHtml);
        }*/
    }
}