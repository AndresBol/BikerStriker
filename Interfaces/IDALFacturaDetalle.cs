using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALFacturaDetalle
    {
        Task<List<FacturaDetalle>> GetAllFacturaDetalle();
        Task<List<FacturaDetalle>> GetAllFacturaDetalleById_Factura(int id_Factura);
        void Insertar(FacturaDetalle facturaDetalle, int id_Factura);
        Task<FacturaDetalle> GetFacturaDetalleByID(int id);
    }
}
