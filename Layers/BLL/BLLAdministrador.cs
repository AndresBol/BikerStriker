using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Interfaces;
using BikerStriker.Layers.DAL;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Layers.BLL
{
    internal class BLLAdministrador : IBLLAdministrador
    {
        public List<Administrador> GetAllAdministrador()
        {
            IDALAdministrador _DALAdministrador = new DALAdministrador();
            return _DALAdministrador.GetAllAdministrador();
        }

        public void Save(Administrador administrador)
        {
            BLLUsuario bllUsuario = new BLLUsuario();
            bllUsuario.Save(administrador);
        }

        public void Remove(int id)
        {
            BLLUsuario bllUsuario = new BLLUsuario();
            bllUsuario.Remove(id);
        }
    }
}
