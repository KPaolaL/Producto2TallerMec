using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityLayerArch
    {

        //cliente
        public int id_cliente { set; get; }
        public string nombre { get; set; }
        public string apellidoPat { get; set; }
        public string apellidoMat { get; set; }
        public string celular { get; set; }
        public string TelOficina { get; set; }
        public string correoP { get; set; }
        public string correoCorp { get; set; }

        //Auto

        public int id_Auto { get; set; }
        public int F_marca { get; set; }
        public string modelo { get; set; }
        public string anio { get; set; }
        public string color { get; set; }
        public string placas { get; set; }
        public int dueño { get; set; }
    }
}
