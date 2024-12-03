using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public class FacturaDetalle
    {
        public FacturaDetalle() { }
        public FacturaDetalle(Producto producto, int cantidad) { 
            this.Producto = producto;
            this.Cantidad = cantidad;
        }
        public int Id { get; set; }
        public Producto Producto {  get; set; }
        public int Cantidad { get; set; }
    }
}
