using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entidades
{
    public partial class Consulta
    {
        public int IdUsuario { get; set; }
        public int IdPublicacion { get; set; }

        public virtual publicaciones IdPublicacionNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
