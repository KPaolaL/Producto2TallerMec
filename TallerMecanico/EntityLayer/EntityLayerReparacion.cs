using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityLayerReparacion
    {
        public int id_reparacion { set; get; }
        public string detalles { get; set; }
        public string garantia { get; set; }
        public string salida { get; set; }
        public int fk_revision { get; set; }
    }
}
