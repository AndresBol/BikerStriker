using BikerStriker.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public class Administrador : Usuario
    {
        public override TipoUsuario TipoUsuario => TipoUsuario.Administrador;
    }
}
