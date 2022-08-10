using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entidades
{
    public class Monografias
    {
        public int IdPublicacion { get; set; }
        public string NombreMono { get; set; }

        public virtual publicaciones IdPublicacionNavigation { get; set; }
    }
}
