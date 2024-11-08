using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IBLLModelo
    {
        List<Modelo> GetAllModelo();

        void Save(Modelo Modelo);
        void Remove(int id);
    }
}
