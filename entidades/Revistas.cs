using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entidades
{
    class Revistas
    {
        public int IdPublicacion { get; set; }
        public int NumArticulos { get; set; }
        public int PagComienzo { get; set; }
        public int PagTerminacion { get; set; }

        public virtual publicaciones IdPublicacionNavigation { get; set; }
    }
}
