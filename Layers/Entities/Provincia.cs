using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public class Provincia
    {
        public int Id { get; set; }
        public string Nombre {  get; set; }

        public Provincia(int id, string nombre) {
            this.Id = id;
            this.Nombre = nombre;
        }

        public override string ToString() {  return Nombre; }
    }
}
