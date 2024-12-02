using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStriker.Layers.Entities
{
    public class OrdenFoto
    {
        public OrdenFoto() { }
        public OrdenFoto(string ruta, Image foto) { 
            this.Ruta = ruta;
            this.Foto = foto;
        }
        public int Id { get; set; }
        public string Ruta {  get; set; }
        public Image Foto { get; set; }
    }
}
