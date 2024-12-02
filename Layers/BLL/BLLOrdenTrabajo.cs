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
        public List<OrdenTrabajo> GetAllOrdenTrabajo()
        {
            IDALOrdenTrabajo _DALOrdenTrabajo = new DALOrdenTrabajo();
            return _DALOrdenTrabajo.GetAllOrdenTrabajo();
        }

        public List<OrdenTrabajo> GetAllOrdenTrabajoFromCliente(int ClienteId)
        {
            var dal = new DALOrdenTrabajo();
            var existe = dal.GetAllOrdenTrabajoFromCliente(ClienteId);

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

        public OrdenTrabajo GetOrdenTrabajoByID(int id)
        {
            IDALOrdenTrabajo _DALOrdenTrabajo = new DALOrdenTrabajo();
            return _DALOrdenTrabajo.GetOrdenTrabajoByID(id);
        }
    }
}
