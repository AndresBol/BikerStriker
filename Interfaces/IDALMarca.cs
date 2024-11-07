using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALMarca
    {
        List<Marca> GetAllMarca();
        void Insertar(Marca marca);
        void Actualizar(Marca marca);
        void Desactivar(int id);
        Marca GetMarcaByID(int id);
    }
}
