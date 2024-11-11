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
    internal class BLLTienda : IBLLTienda
    {
        public List<Tienda> GetAllTienda()
        {
            IDALTienda _DALTienda = new DALTienda();
            return _DALTienda.GetAllTienda();
        }

        public void Save(Tienda tienda)
        {
            var dal = new DALTienda();
            var existe = dal.GetTiendaByID(tienda.Id);

            if (existe != null)
            {
                dal.Actualizar(tienda);
            }
            else
            {
                dal.Insertar(tienda);
            }
        }

        public void Remove(int id)
        {
            var dal = new DALTienda();
            var existe = dal.GetTiendaByID(id);

            if (existe != null)
            {
                dal.Desactivar(id);
            }
            else
            {
                throw new ApplicationException($"La Tienda con id {id} no existe!");
            }
        }
    }
}
