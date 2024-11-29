using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Interfaces
{
    internal interface IDALTarjeta
    {
        List<Tarjeta> GetAllTarjeta();
        List<Tarjeta> GetAllTarjetaFromCliente(int ClienteId);
        int GetClientIdFromId(int id);
        void Insertar(Tarjeta tarjeta, int ClienteId);
        void Actualizar(Tarjeta tarjeta, int ClienteId);
        void Desactivar(int id);
        Tarjeta GetTarjetaByID(int id);
    }
}
