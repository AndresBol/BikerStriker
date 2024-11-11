using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALAdministrador
    {
        List<Administrador> GetAllAdministrador();
        Administrador GetAdministradorByID(int id);
    }
}
