using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALProducto
    {
        Task<List<Producto>> GetAllProducto();
        Task<List<Producto>> GetSoloServicio();
        Task<List<Producto>> GetSoloProducto();
        Task<List<Producto>> GetProductosByCategoria(int CategoriaId);
        Task<List<Producto>> GetServiciosByCategoria(int CategoriaId);
        void Insertar(Producto producto);
        void Actualizar(Producto producto);
        void Desactivar(int id);
        Task<Producto> GetProductoByID(int id);
    }
}
