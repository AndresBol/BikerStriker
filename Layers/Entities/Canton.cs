using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public class Canton
    {
        public int Id { get; set; }
        public Provincia Provincia { get; set; }
        public string Nombre { get; set; }

        public Canton(int id, Provincia provincia, string nombre)
        {
            this.Id = id;
            this.Provincia = provincia;
            this.Nombre = nombre;
        }
        public override string ToString() { return Nombre; }

    }
}
