using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public class Distrito
    {
        public int Id { get; set; }
        public Canton Canton { get; set; }
        public string Nombre { get; set; }
        public Distrito(int id, Canton canton, string nombre)
        {
            this.Id = id;
            this.Canton = canton;
            this.Nombre = nombre;
        }
        public override string ToString() { return Nombre; }

    }
}
