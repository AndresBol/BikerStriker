using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BikerStriker.Layers.Entities
{
    public class Factura
    {
        public Factura() { }
        public Factura(Cliente cliente, Tarjeta tarjeta, double totalColones, double totalDolares) {
            this.Cliente = cliente;
            this.Tarjeta = tarjeta;
            this.TotalColones = totalColones;
            this.TotalDolares = totalDolares;
        }
        public int Id { get; set; }
        public OrdenTrabajo OrdenTrabajo { get; set; }
        public Cliente Cliente { get; set; }
        public Tarjeta Tarjeta { get; set; }
        public double TotalColones { get; set; }
        public double TotalDolares { get; set; }
        public List<FacturaDetalle> FacturaDetalle { get; set; }
    }
}
