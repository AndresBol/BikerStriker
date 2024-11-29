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
    internal class BLLTarjeta : IBLLTarjeta
    {
        public List<Tarjeta> GetAllTarjeta()
        {
            IDALTarjeta _DALTarjeta = new DALTarjeta();
            return _DALTarjeta.GetAllTarjeta();
        }

        public List<Tarjeta> GetAllTarjetaFromCliente(int ClienteId)
        {
            var dal = new DALTarjeta();
            var existe = dal.GetAllTarjetaFromCliente(ClienteId);

            if (existe != null)
            {
                return existe;
            }
            else
            {
                throw new ApplicationException($"El cliente con {ClienteId} no tiene tarjetas!");
            }
        }

        public int GetClientIdFromId(int id)
        {
            var dal = new DALTarjeta();

            int existe = dal.GetClientIdFromId(id);

            if (existe != 0)
            {
                return existe;
            }
            else
            {
                throw new ApplicationException($"La tarjeta con id {id} no tiene cliente!");
            }
        }

        public void Save(Tarjeta tarjeta, int ClienteId)
        {
            var dal = new DALTarjeta();
            var existe = dal.GetTarjetaByID(tarjeta.Id);

            if (existe != null)
            {
                dal.Actualizar(tarjeta, ClienteId);
            }
            else
            {
                dal.Insertar(tarjeta, ClienteId);
            }
        }

        public void Remove(int id)
        {
            var dal = new DALTarjeta();
            var existe = dal.GetTarjetaByID(id);

            if (existe != null)
            {
                dal.Desactivar(id);
            }
            else
            {
                throw new ApplicationException($"La Tarjeta con id {id} no existe!");
            }
        }
    }
}
