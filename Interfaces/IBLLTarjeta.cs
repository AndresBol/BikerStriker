using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IBLLTarjeta
    {
        List<Tarjeta> GetAllTarjeta();
        List<Tarjeta> GetAllTarjetaFromCliente(int ClienteId);
        int GetClientIdFromId(int id);
        void Save(Tarjeta tarjeta, int ClienteId);
        void Remove(int id);
    }
}
