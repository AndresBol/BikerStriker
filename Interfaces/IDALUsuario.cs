using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALUsuario
    {
        Usuario Login(string pLogin, string pPassword);
        List<Usuario> GetAllUsuario();
        void Insertar(Usuario usuario);
        void Actualizar(Usuario usuario);
        void Desactivar(int id);
        int GetIdByEmail(string email);
    }
}
