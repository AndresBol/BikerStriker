using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IBLLVendedor
    {
        List<Vendedor> GetAllVendedor();

        void Save(Vendedor vendedor);
        void Remove(int id);
    }
}
