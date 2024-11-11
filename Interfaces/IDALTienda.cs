using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALTienda
    {
        List<Tienda> GetAllTienda();
        void Insertar(Tienda tienda);
        void Actualizar(Tienda tienda);
        void Desactivar(int id);
        Tienda GetTiendaByID(int id);
    }
}
