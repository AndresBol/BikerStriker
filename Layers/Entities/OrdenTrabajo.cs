using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public class OrdenTrabajo
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public Image Firma {  get; set; }
        public Cliente Cliente { get; set; }
        public Bicicleta Bicicleta { get; set; }
        public List<OrdenDetalle> OrdenDetalle { get; set; }
        public List<OrdenFoto> ordenFoto { get; set; }
    }
}
