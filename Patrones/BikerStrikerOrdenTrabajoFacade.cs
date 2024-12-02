using BikerStriker.Layers.BLL;
using BikerStriker.Layers.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Patrones
{
    public class BikerStrikerOrdenTrabajoFacade
    {
        public OrdenTrabajo OrdenTrabajo { get; set; }

        public bool GuardarOrdenTrabajo()
        {
            BLLOrdenTrabajo bLLOrdenTrabajo = new BLLOrdenTrabajo();
            BLLOrdenDetalle bllOrdenDetalle = new BLLOrdenDetalle();
            BLLOrdenFoto bllOrdenFoto = new BLLOrdenFoto();

            bLLOrdenTrabajo.Save(OrdenTrabajo);

            OrdenTrabajo.Id = bLLOrdenTrabajo.GetIdOrdenTrabajo(OrdenTrabajo);

            if(OrdenTrabajo.Id != -1)
            {
                foreach (var oDetalle in OrdenTrabajo.OrdenDetalle)
                {
                    bllOrdenDetalle.Save(oDetalle, OrdenTrabajo.Id);
                }

                foreach (var oFoto in OrdenTrabajo.OrdenFoto)
                {
                    bllOrdenFoto.Save(oFoto, OrdenTrabajo.Id);
                }
            }

            return OrdenTrabajo.Id != -1;
        }

        private Image GenerarQR_OrdenTrabajo()
        {
            return null;
        }

        public void GenerarPDF() 
        { 
        
        }

        public bool EnviarOrdenTrabajoEmail()
        {
            return false;
        }
    }
}
