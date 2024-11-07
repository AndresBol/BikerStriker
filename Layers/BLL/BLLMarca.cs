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
    internal class BLLMarca : IBLLMarca
    {
        public List<Marca> GetAllMarca()
        {
            IDALMarca _DALMarca = new DALMarca();
            return _DALMarca.GetAllMarca();
        }

        public void Save(Marca marca)
        {
            var dal = new DALMarca();
            var existe = dal.GetMarcaByID(marca.Id);

            if (existe != null)
            {
                dal.Actualizar(marca);
            }
            else
            {
                dal.Insertar(marca);
            }
        }

        public void Remove(int id)
        {
            var dal = new DALMarca();
            var existe = dal.GetMarcaByID(id);

            if (existe != null)
            {
                dal.Desactivar(id);
            }
            else
            {
                throw new ApplicationException($"La Marca con id {id} no existe!");
            }
        }
    }
}
