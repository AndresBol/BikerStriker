using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IBLLOrdenFoto
    {
        List<OrdenFoto> GetAllOrdenFoto();
        List<OrdenFoto> GetAllOrdenFotoById_OrdenTrabajo(int ClienteId);
        void Save(OrdenFoto ordenFoto, int id_OrdenTrabajo);
    }
}
