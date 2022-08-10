using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entidades
{
    public class Prestamo
    {
        public int IdPrestamo { get; set; }
        public DateTime FechaInicioPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
