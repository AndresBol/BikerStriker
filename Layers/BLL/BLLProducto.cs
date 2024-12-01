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
    internal class BLLProducto : IBLLProducto
    {
        public async Task<List<Producto>> GetAllProducto()
        {
            IDALProducto _DALProducto = new DALProducto();
            return await _DALProducto.GetAllProducto();
        }

        public async Task<List<Producto>> GetSoloServicio()
        {
            IDALProducto _DALProducto = new DALProducto();
            return await _DALProducto.GetSoloServicio();
        }

        public async Task<List<Producto>> GetSoloProducto()
        {
            IDALProducto _DALProducto = new DALProducto();
            return await _DALProducto.GetSoloProducto();
        }

        public async Task<List<Producto>> GetProductosByCategoria(int CategoriaId)
        {
            IDALProducto _DALProducto = new DALProducto();
            return await _DALProducto.GetProductosByCategoria(CategoriaId);
        }

        public async Task<List<Producto>> GetServiciosByCategoria(int CategoriaId)
        {
            IDALProducto _DALProducto = new DALProducto();
            return await _DALProducto.GetServiciosByCategoria(CategoriaId);
        }

        public void Save(Producto producto)
        {
            var dal = new DALProducto();
            var existe = dal.GetProductoByID(producto.Id);

            if (existe.Result != null)
            {
                dal.Actualizar(producto);
            }
            else
            {
                dal.Insertar(producto);
            }
        }

        public void Remove(int id)
        {
            var dal = new DALProducto();
            var existe = dal.GetProductoByID(id);

            if (existe != null)
            {
                dal.Desactivar(id);
            }
            else
            {
                throw new ApplicationException($"La Producto con id {id} no existe!");
            }
        }
    }
}
