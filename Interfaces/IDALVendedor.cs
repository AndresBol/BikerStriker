using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALVendedor
    {
        List<Vendedor> GetAllVendedor();
        void Insertar(Vendedor vendedor);
        void Actualizar(Vendedor vendedor);
        void Desactivar(int id);
        Vendedor GetVendedorByID(int id);
    }
}
