using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Interfaces;
using BikerStriker.Layers.DAL;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Layers.BLL
{
    internal class BLLFacturaDetalle : IBLLFacturaDetalle
    {
        public Task<List<FacturaDetalle>> GetAllFacturaDetalle()
        {
            IDALFacturaDetalle _DALFacturaDetalle = new DALFacturaDetalle();
            return _DALFacturaDetalle.GetAllFacturaDetalle();
        }

        public Task<List<FacturaDetalle>> GetAllFacturaDetalleById_Factura(int ClienteId)
        {
            IDALFacturaDetalle _DALFacturaDetalle = new DALFacturaDetalle();
            return _DALFacturaDetalle.GetAllFacturaDetalleById_Factura(ClienteId);
        }

        public void Save(FacturaDetalle facturaDetalle, int id_Factura)
        {
            var dal = new DALFacturaDetalle();
            dal.Insertar(facturaDetalle, id_Factura);
        }
    }
}
