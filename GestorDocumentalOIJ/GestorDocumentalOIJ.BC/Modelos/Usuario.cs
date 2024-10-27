using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RolID { get; set; }
        public bool Activo { get; set; }
        public bool Eliminado { get; set; }
    }
}
