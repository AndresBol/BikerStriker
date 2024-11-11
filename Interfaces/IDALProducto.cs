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
        List<Producto> GetAllProducto();
        void Insertar(Producto producto);
        void Actualizar(Producto producto);
        void Desactivar(int id);
        Producto GetProductoByID(int id);
    }
}
