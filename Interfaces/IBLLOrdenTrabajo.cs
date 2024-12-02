using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IBLLOrdenTrabajo
    {
        List<OrdenTrabajo> GetAllOrdenTrabajo();
        List<OrdenTrabajo> GetAllOrdenTrabajoFromCliente(int ClienteId);
        void Save(OrdenTrabajo ordenTrabajo);
        OrdenTrabajo GetOrdenTrabajoByID(int id);
    }
}
