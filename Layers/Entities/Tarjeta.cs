using BikerStriker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public short CodigoSeguridad { get; set; }
        public TipoTarjeta TipoTarjeta { get; set; }
    }
}
