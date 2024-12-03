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
        Task<List<OrdenTrabajo>> GetAllOrdenTrabajo();
        Task<List<OrdenTrabajo>> GetAllOrdenTrabajoFromCliente(int ClienteId);
        Task<List<OrdenTrabajo>> GetAllPendingOrdenTrabajoFromCliente(int ClienteId);
        void ActualizarPago(int id);
        void Save(OrdenTrabajo ordenTrabajo);
        Task<OrdenTrabajo> GetOrdenTrabajoByID(int id);
        int GetIdOrdenTrabajo(OrdenTrabajo ordenTrabajo);
    }
}
