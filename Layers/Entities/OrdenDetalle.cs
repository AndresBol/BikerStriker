using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public class OrdenDetalle
    {
        public OrdenDetalle() { }
        public OrdenDetalle(Producto servicio) { 
            this.Servicio = servicio;
        }
        public int Id { get; set; }
        public Producto Servicio {  get; set; }
    }
}
