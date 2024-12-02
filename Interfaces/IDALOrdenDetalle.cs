using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALOrdenDetalle
    {
        Task<List<OrdenDetalle>> GetAllOrdenDetalle();
        Task<List<OrdenDetalle>> GetAllOrdenDetalleById_OrdenTrabajo(int id_OrdenTrabajo);
        void Insertar(OrdenDetalle ordenDetalle, int id_OrdenTrabajo);
        Task<OrdenDetalle> GetOrdenDetalleByID(int id);
    }
}
