using BikerStriker.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public class Vendedor : Usuario
    {
        public int VendedorId { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Image Fotografia { get; set; }
        public override TipoUsuario TipoUsuario => TipoUsuario.Vendedor;
    }
}
