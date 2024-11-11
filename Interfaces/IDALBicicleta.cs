using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALBicicleta
    {
        List<Bicicleta> GetAllBicicleta();
        List<Bicicleta> GetAllBicicletaFromCliente(int ClienteId);
        int GetClientIdFromId(int id);
        void Insertar(Bicicleta bicicleta, int ClienteId);
        void Actualizar(Bicicleta bicicleta, int ClienteId);
        void Desactivar(int id);
        Bicicleta GetBicicletaByID(int id);
    }
}
