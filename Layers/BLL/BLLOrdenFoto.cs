using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStriker.Interfaces;
using BikerStriker.Layers.DAL;
using BikerStriker.Layers.Entities;

namespace BikerStriker.Layers.BLL
{
    internal class BLLOrdenFoto : IBLLOrdenFoto
    {
        public List<OrdenFoto> GetAllOrdenFoto()
        {
            IDALOrdenFoto _DALOrdenFoto = new DALOrdenFoto();
            return _DALOrdenFoto.GetAllOrdenFoto();
        }

        public List<OrdenFoto> GetAllOrdenFotoById_OrdenTrabajo(int ClienteId)
        {
            IDALOrdenFoto _DALOrdenFoto = new DALOrdenFoto();
            return _DALOrdenFoto.GetAllOrdenFotoById_OrdenTrabajo(ClienteId);
        }

        public void Save(OrdenFoto ordenFoto, int id_OrdenTrabajo)
        {
            var dal = new DALOrdenFoto();
            dal.Insertar(ordenFoto, id_OrdenTrabajo);
        }
    }
}
