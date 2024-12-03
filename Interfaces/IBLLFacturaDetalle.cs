using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IBLLFacturaDetalle
    {
        Task<List<FacturaDetalle>> GetAllFacturaDetalle();
        Task<List<FacturaDetalle>> GetAllFacturaDetalleById_Factura(int ClienteId);
        void Save(FacturaDetalle facturaDetalle, int id_Factura);
    }
}
