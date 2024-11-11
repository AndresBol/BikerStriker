using BikerStriker.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public class Bicicleta
    {
        public int Id { get; set; }
        public string NumeroSerie { get; set; }
        public Color Color { get; set; }
        public Modelo Modelo { get; set; }

    }
}
