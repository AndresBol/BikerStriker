using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IBLLCliente
    {
        List<Cliente> GetAllCliente();
        Cliente GetClienteByID(int id);
        Cliente GetClienteByUserID(int id);
        void Save(Cliente cliente);
        void Remove(int id);
    }
}
