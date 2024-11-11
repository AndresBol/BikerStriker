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
    internal class BLLCliente : IBLLCliente
    {
        public List<Cliente> GetAllCliente()
        {
            IDALCliente _DALCliente = new DALCliente();
            return _DALCliente.GetAllCliente();
        }

        public Cliente GetClienteByID(int id)
        {
            var dal = new DALCliente();
            var existe = dal.GetClienteByID(id);

            if (existe != null)
            {
                return existe;
            }
            else
            {
                throw new ApplicationException($"El Cliente con id {id} no existe!");
            }
        }

        public void Save(Cliente cliente)
        {
            var dal = new DALCliente();
            var existe = dal.GetClienteByID(cliente.ClienteId);

            if (existe != null)
            {
                dal.Actualizar(cliente);
            }
            else
            {
                dal.Insertar(cliente);
            }
        }

        public void Remove(int id)
        {
            var dal = new DALCliente();
            var existe = dal.GetClienteByID(id);

            if (existe != null)
            {
                dal.Desactivar(id);
            }
            else
            {
                throw new ApplicationException($"El Cliente con id {id} no existe!");
            }
        }
    }
}
