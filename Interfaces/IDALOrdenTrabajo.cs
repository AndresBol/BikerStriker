using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALOrdenTrabajo
    {
        Task<List<OrdenTrabajo>> GetAllOrdenTrabajo();
        Task<List<OrdenTrabajo>> GetAllOrdenTrabajoFromCliente(int ClienteId);
        Task<List<OrdenTrabajo>> GetAllPendingOrdenTrabajoFromCliente(int ClienteId);
        void ActualizarPago(int id);
        void Insertar(OrdenTrabajo ordenTrabajo);
        Task<OrdenTrabajo> GetOrdenTrabajoByID(int id);
        int GetIdOrdenTrabajo(OrdenTrabajo ordenTrabajo);
    }
}
