using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALOrdenFoto
    {
        List<OrdenFoto> GetAllOrdenFoto();
        List<OrdenFoto> GetAllOrdenFotoById_OrdenTrabajo(int id_OrdenTrabajo);
        void Insertar(OrdenFoto ordenFoto, int id_OrdenTrabajo);
        OrdenFoto GetOrdenFotoByID(int id);
    }
}
