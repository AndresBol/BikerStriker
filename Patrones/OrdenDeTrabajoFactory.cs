using BikerStriker.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Patrones
{
    public class OrdenDeTrabajoFactory
    {
        public OrdenTrabajo CrearOrdenDeTrabajo(DateTime fechaInicio, DateTime fechaFinalizacion, Image firma, Cliente cliente, Bicicleta bicicleta, List<Producto> servicios, List<OrdenFoto> ordenFoto)
        {
            OrdenTrabajo ordenTrabajo = new OrdenTrabajo();

            ordenTrabajo.FechaInicio = fechaInicio;
            ordenTrabajo.FechaFinalizacion = fechaFinalizacion;
            ordenTrabajo.Firma = firma;
            ordenTrabajo.Cliente = cliente;
            ordenTrabajo.Bicicleta = bicicleta;
            ordenTrabajo.OrdenDetalle = servicios.Select(p => new OrdenDetalle { Servicio = p }).ToList();
            ordenTrabajo.OrdenFoto = ordenFoto;

            return ordenTrabajo;
        }
    }
}
