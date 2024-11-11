using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALCategoria
    {
        List<Categoria> GetAllCategoria();
        void Insertar(Categoria categoria);
        void Actualizar(Categoria categoria);
        void Desactivar(int id);
        Categoria GetCategoriaByID(int id);
    }
}
