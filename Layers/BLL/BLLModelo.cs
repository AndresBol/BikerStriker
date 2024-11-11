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
    internal class BLLModelo : IBLLModelo
    {
        public List<Modelo> GetAllModelo()
        {
            IDALModelo _DALModelo = new DALModelo();
            return _DALModelo.GetAllModelo();
        }

        public void Save(Modelo modelo)
        {
            var dal = new DALModelo();
            var existe = dal.GetModeloByID(modelo.Id);

            if (existe.Marca != null)
            {
                dal.Actualizar(modelo);
            }
            else
            {
                dal.Insertar(modelo);
            }
        }

        public void Remove(int id)
        {
            var dal = new DALModelo();
            var existe = dal.GetModeloByID(id);

            if (existe != null)
            {
                dal.Desactivar(id);
            }
            else
            {
                throw new ApplicationException($"La Modelo con id {id} no existe!");
            }
        }

        public Modelo GetModeloByID(int id)
        {
            var dal = new DALModelo();
            var existe = dal.GetModeloByID(id);

            if (existe != null)
            {
                return existe;
            }
            else
            {
                throw new ApplicationException($"La Modelo con id {id} no existe!");
            }
        }
    }
}
