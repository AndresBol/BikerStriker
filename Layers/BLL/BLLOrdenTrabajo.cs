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
    internal class BLLOrdenTrabajo : IBLLOrdenTrabajo
    {
        public async Task<List<OrdenTrabajo>> GetAllOrdenTrabajo()
        {
            IDALOrdenTrabajo _DALOrdenTrabajo = new DALOrdenTrabajo();
            return await _DALOrdenTrabajo.GetAllOrdenTrabajo();
        }

        public async Task<List<OrdenTrabajo>> GetAllOrdenTrabajoFromCliente(int ClienteId)
        {
            var dal = new DALOrdenTrabajo();
            var existe = await dal.GetAllOrdenTrabajoFromCliente(ClienteId);

            if (existe != null)
            {
                return existe;
            }
            else
            {
                throw new ApplicationException($"El cliente con {ClienteId} no tiene ordenTrabajos!");
            }
        }

        public void Save(OrdenTrabajo ordenTrabajo)
        {
            var dal = new DALOrdenTrabajo();
            dal.Insertar(ordenTrabajo);
        }

        public async Task<OrdenTrabajo> GetOrdenTrabajoByID(int id)
        {
            IDALOrdenTrabajo _DALOrdenTrabajo = new DALOrdenTrabajo();
            return await _DALOrdenTrabajo.GetOrdenTrabajoByID(id);
        }

        public int GetIdOrdenTrabajo(OrdenTrabajo ordenTrabajo)
        {
            IDALOrdenTrabajo _DALOrdenTrabajo = new DALOrdenTrabajo();
            return _DALOrdenTrabajo.GetIdOrdenTrabajo(ordenTrabajo);
        }
    }
}
