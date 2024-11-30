using BikerStriker.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public class Cliente : Usuario
    {
        public int ClienteId { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public TipoGenero Genero { get; set; }
        public override TipoUsuario TipoUsuario => TipoUsuario.Cliente;

        public List<Bicicleta> Bicicletas { get; set;}
        public List<Tarjeta> Tarjetas { get; set; }
        public List<Contacto> Contactos { get; set; }

    }
}
