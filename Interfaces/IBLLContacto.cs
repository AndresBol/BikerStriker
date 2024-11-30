using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IBLLContacto
    {
        List<Contacto> GetAllContacto();
        List<Contacto> GetAllContactoFromCliente(int ClienteId);
        int GetClientIdFromId(int id);
        void Save(Contacto contacto, int ClienteId);
        void Remove(int id);
    }
}
