using BikerStriker.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Patrones
{
    public class FacturaFactory
    {
        public Factura CrearFactura(Cliente cliente, Tarjeta tarjeta, double totalColones, double totalDolares, OrdenTrabajo ordenTrabajo, List<FacturaDetalle> facturaDetalle)
        {
            Factura factura = new Factura(cliente, tarjeta, totalColones, totalDolares);

            factura.OrdenTrabajo = ordenTrabajo;
            factura.FacturaDetalle = facturaDetalle;

            return factura;
        }
    }
}
