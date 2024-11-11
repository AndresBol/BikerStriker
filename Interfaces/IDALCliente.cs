using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALCliente
    {
        List<Cliente> GetAllCliente();
        void Insertar(Cliente cliente);
        void Actualizar(Cliente cliente);
        void Desactivar(int id);
        Cliente GetClienteByID(int id);
    }
}
