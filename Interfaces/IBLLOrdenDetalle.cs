using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IBLLOrdenDetalle
    {
        Task<List<OrdenDetalle>> GetAllOrdenDetalle();
        Task<List<OrdenDetalle>> GetAllOrdenDetalleById_OrdenTrabajo(int ClienteId);
        void Save(OrdenDetalle ordenDetalle, int id_OrdenTrabajo);
    }
}
