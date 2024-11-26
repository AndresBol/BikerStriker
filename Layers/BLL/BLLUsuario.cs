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
    internal class BLLUsuario : IBLLUsuario
    {
        public Usuario Login(string pLogin, string pPassword)
        {
            IDALUsuario _DALUsuario = new DALUsuario();

            return _DALUsuario.Login(pLogin, pPassword);
        }
        public List<Usuario> GetAllUsuario()
        {
            IDALUsuario _DALUsuario = new DALUsuario();
            return _DALUsuario.GetAllUsuario();
        }

        public void Save(Usuario usuario)
        {
            var dal = new DALUsuario();
            var existe = dal.GetUsuarioByID(usuario.UsuarioId);

            if (existe != null)
            {
                dal.Actualizar(usuario);
            }
            else
            {
                dal.Insertar(usuario);
            }
        }

        public void Remove(int id)
        {
            var dal = new DALUsuario();
            var existe = dal.GetUsuarioByID(id);

            if (existe != null)
            {
                dal.Desactivar(id);
            }
            else
            {
                throw new ApplicationException($"El Usuario con id {id} no existe!");
            }
        }

        public int GetIdByEmail(string email)
        {
            var dal = new DALUsuario();
            int existe = dal.GetIdByEmail(email);

            if (existe != 0)
            {
                return existe;
            }
            else
            {
                throw new ApplicationException($"El Usuario con email {email} no existe!");
            }
        }
    }
}
