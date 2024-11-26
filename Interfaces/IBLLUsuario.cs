using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IBLLUsuario
    {
        Usuario Login(string pLogin, string pPassword);
        List<Usuario> GetAllUsuario();
        void Save(Usuario usuario);
        void Remove(int id);
        int GetIdByEmail(string email);
    }
}
