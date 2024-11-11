using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IBLLTienda
    {
        List<Tienda> GetAllTienda();

        void Save(Tienda tienda);
        void Remove(int id);
    }
}
