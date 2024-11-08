using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALModelo
    {
        List<Modelo> GetAllModelo();
        void Insertar(Modelo modelo);
        void Actualizar(Modelo modelo);
        void Desactivar(int id);
        Modelo GetModeloByID(int id);
    }
}
