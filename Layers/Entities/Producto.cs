using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public double Dolarizado { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public Categoria Categoria { get; set; }
        public bool EsServicio { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
