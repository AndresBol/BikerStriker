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
    internal class BLLOrdenDetalle : IBLLOrdenDetalle
    {
        public Task<List<OrdenDetalle>> GetAllOrdenDetalle()
        {
            IDALOrdenDetalle _DALOrdenDetalle = new DALOrdenDetalle();
            return _DALOrdenDetalle.GetAllOrdenDetalle();
        }

        public Task<List<OrdenDetalle>> GetAllOrdenDetalleById_OrdenTrabajo(int ClienteId)
        {
            IDALOrdenDetalle _DALOrdenDetalle = new DALOrdenDetalle();
            return _DALOrdenDetalle.GetAllOrdenDetalleById_OrdenTrabajo(ClienteId);
        }

        public void Save(OrdenDetalle ordenDetalle, int id_OrdenTrabajo)
        {
            var dal = new DALOrdenDetalle();
            dal.Insertar(ordenDetalle, id_OrdenTrabajo);
        }
    }
}
