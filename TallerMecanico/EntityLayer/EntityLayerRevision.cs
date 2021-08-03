using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityLayerRevision
    {
        public int id_revision { set; get; }
        public string entrada { get; set; }
        public string falla { get; set; }
        public string diagnostico { get; set; }
        public string authorizacion { get; set; }
        public int auto { get; set; }
        public int mecanico { get; set; }
    }
}
