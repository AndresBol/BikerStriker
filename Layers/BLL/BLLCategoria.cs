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
    internal class BLLCategoria : IBLLCategoria
    {
        public List<Categoria> GetAllCategoria()
        {
            IDALCategoria _DALCategoria = new DALCategoria();
            return _DALCategoria.GetAllCategoria();
        }

        public void Save(Categoria categoria)
        {
            var dal = new DALCategoria();
            var existe = dal.GetCategoriaByID(categoria.Id);

            if (existe != null)
            {
                dal.Actualizar(categoria);
            }
            else
            {
                dal.Insertar(categoria);
            }
        }

        public void Remove(int id)
        {
            var dal = new DALCategoria();
            var existe = dal.GetCategoriaByID(id);

            if (existe != null)
            {
                dal.Desactivar(id);
            }
            else
            {
                throw new ApplicationException($"La Categoria con id {id} no existe!");
            }
        }
    }
}
