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
    internal class BLLBicicleta : IBLLBicicleta
    {
        public List<Bicicleta> GetAllBicicleta()
        {
            IDALBicicleta _DALBicicleta = new DALBicicleta();
            return _DALBicicleta.GetAllBicicleta();
        }

        public List<Bicicleta> GetAllBicicletaFromCliente(int ClienteId)
        {
            var dal = new DALBicicleta();
            var existe = dal.GetAllBicicletaFromCliente(ClienteId);

            if (existe != null)
            {
                return existe;
            }
            else
            {
                throw new ApplicationException($"El cliente con {ClienteId} no tiene bicicletas!");
            }
        }

        public void Save(Bicicleta bicicleta, int ClienteId)
        {
            var dal = new DALBicicleta();
            var existe = dal.GetBicicletaByID(bicicleta.Id);

            if (existe != null)
            {
                dal.Actualizar(bicicleta);
            }
            else
            {
                dal.Insertar(bicicleta, ClienteId);
            }
        }

        public void Remove(int id)
        {
            var dal = new DALBicicleta();
            var existe = dal.GetBicicletaByID(id);

            if (existe != null)
            {
                dal.Desactivar(id);
            }
            else
            {
                throw new ApplicationException($"La Bicicleta con id {id} no existe!");
            }
        }
    }
}
