using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IBLLMarca
    {
        List<Marca> GetAllMarca();

        void Save(Marca marca);
        void Remove(int id);
    }
}
