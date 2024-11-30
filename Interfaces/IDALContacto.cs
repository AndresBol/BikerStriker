using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALContacto
    {
        List<Contacto> GetAllContacto();
        List<Contacto> GetAllContactoFromCliente(int ClienteId);
        int GetClientIdFromId(int id);
        void Insertar(Contacto contacto, int ClienteId);
        void Actualizar(Contacto contacto, int ClienteId);
        void Desactivar(int id);
        Contacto GetContactoByID(int id);
    }
}
