using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BikerStriker.Interfaces;
using BikerStriker.Layers.DAL;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Layers.BLL
{
    internal class BLLFactura : IBLLFactura
    {
        public async Task<List<Factura>> GetAllFactura()
        {
            IDALFactura _DALFactura = new DALFactura();
            return await _DALFactura.GetAllFactura();
        }

        public async Task<List<Factura>> GetAllFacturaFromCliente(int ClienteId)
        {
            var dal = new DALFactura();
            var existe = await dal.GetAllFacturaFromCliente(ClienteId);

            if (existe != null)
            {
                return existe;
            }
            else
            {
                throw new ApplicationException($"El cliente con {ClienteId} no tiene facturas!");
            }
        }

        public void Save(Factura factura, XmlDocument XML_Factura)
        {
            var dal = new DALFactura();
            dal.Insertar(factura, XML_Factura);
        }

        public async Task<Factura> GetFacturaByID(int id)
        {
            IDALFactura _DALFactura = new DALFactura();
            return await _DALFactura.GetFacturaByID(id);
        }

        public int GetIdFactura(Factura factura)
        {
            IDALFactura _DALFactura = new DALFactura();
            return _DALFactura.GetIdFactura(factura);
        }

        public XmlDocument GetXMLFacturaByID(int id)
        {
            IDALFactura _DALFactura = new DALFactura();
            return _DALFactura.GetXMLFacturaByID(id);
        }
    }
}
