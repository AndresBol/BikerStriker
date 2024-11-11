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
    internal class BLLVendedor : IBLLVendedor
    {
        public List<Vendedor> GetAllVendedor()
        {
            IDALVendedor _DALVendedor = new DALVendedor();
            return _DALVendedor.GetAllVendedor();
        }

        public void Save(Vendedor vendedor)
        {
            var dal = new DALVendedor();
            var existe = dal.GetVendedorByID(vendedor.VendedorId);

            if (existe != null)
            {
                dal.Actualizar(vendedor);
            }
            else
            {
                dal.Insertar(vendedor);
            }
        }

        public void Remove(int id)
        {
            var dal = new DALVendedor();
            var existe = dal.GetVendedorByID(id);

            if (existe != null)
            {
                dal.Desactivar(id);
            }
            else
            {
                throw new ApplicationException($"El Vendedor con id {id} no existe!");
            }
        }
    }
}
