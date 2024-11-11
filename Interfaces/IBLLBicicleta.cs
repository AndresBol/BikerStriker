using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IBLLBicicleta
    {
        List<Bicicleta> GetAllBicicleta();
        List<Bicicleta> GetAllBicicletaFromCliente(int ClienteId);

        void Save(Bicicleta bicicleta, int ClienteId);
        void Remove(int id);
    }
}
