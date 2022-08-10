using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entidades
{
    class Textos
    {
        public int IdPublicacion { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public int NumPaginas { get; set; }

        public virtual publicaciones IdPublicacionNavigation { get; set; }
    }
}
