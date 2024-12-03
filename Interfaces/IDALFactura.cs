using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALFactura
    {
        Task<List<Factura>> GetAllFactura();
        Task<List<Factura>> GetAllFacturaFromCliente(int ClienteId);
        void Insertar(Factura factura, XmlDocument XML_Factura);
        Task<Factura> GetFacturaByID(int id);
        int GetIdFactura(Factura factura);
        XmlDocument GetXMLFacturaByID(int id);
    }
}
