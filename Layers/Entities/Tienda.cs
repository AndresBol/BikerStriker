using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public class Tienda
    {
        public int Id { get; set; }
        public string CedulaJuridica { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
