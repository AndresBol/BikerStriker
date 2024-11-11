using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IBLLCategoria
    {
        List<Categoria> GetAllCategoria();

        void Save(Categoria categoria);
        void Remove(int id);
    }
}
