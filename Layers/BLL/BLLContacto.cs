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
    internal class BLLContacto : IBLLContacto
    {
        public List<Contacto> GetAllContacto()
        {
            IDALContacto _DALContacto = new DALContacto();
            return _DALContacto.GetAllContacto();
        }

        public List<Contacto> GetAllContactoFromCliente(int ClienteId)
        {
            var dal = new DALContacto();
            var existe = dal.GetAllContactoFromCliente(ClienteId);

            if (existe != null)
            {
                return existe;
            }
            else
            {
                throw new ApplicationException($"El cliente con {ClienteId} no tiene contactos!");
            }
        }

        public int GetClientIdFromId(int id)
        {
            var dal = new DALContacto();

            int existe = dal.GetClientIdFromId(id);

            if (existe != 0)
            {
                return existe;
            }
            else
            {
                throw new ApplicationException($"La contacto con id {id} no tiene cliente!");
            }
        }

        public void Save(Contacto contacto, int ClienteId)
        {
            var dal = new DALContacto();
            var existe = dal.GetContactoByID(contacto.Id);

            if (existe != null)
            {
                dal.Actualizar(contacto, ClienteId);
            }
            else
            {
                dal.Insertar(contacto, ClienteId);
            }
        }

        public void Remove(int id)
        {
            var dal = new DALContacto();
            var existe = dal.GetContactoByID(id);

            if (existe != null)
            {
                dal.Desactivar(id);
            }
            else
            {
                throw new ApplicationException($"La Contacto con id {id} no existe!");
            }
        }
    }
}
