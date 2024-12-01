using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IBLLProducto
    {
        Task<List<Producto>> GetAllProducto();
        Task<List<Producto>> GetSoloServicio();
        Task<List<Producto>> GetSoloProducto();
        Task<List<Producto>> GetProductosByCategoria(int CategoriaId);
        Task<List<Producto>> GetServiciosByCategoria(int CategoriaId);
        void Save(Producto producto);
        void Remove(int id);
    }
}
