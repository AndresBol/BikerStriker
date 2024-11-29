using BikerStriker.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public abstract class Usuario
    {
        public int UsuarioId { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public abstract TipoUsuario TipoUsuario { get; }

        public override string ToString()
        {
            return $"{Nombre} {Apellidos}";
        }
    }
}
