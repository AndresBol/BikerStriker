using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public class Modelo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Marca Marca { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
