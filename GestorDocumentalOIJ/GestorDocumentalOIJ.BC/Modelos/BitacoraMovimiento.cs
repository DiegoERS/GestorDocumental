using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.Modelos
{
    public class BitacoraMovimiento
    {
        public int IdMovimiento { get; set; }
        public int VersionID { get; set; }
        public string FechaIngreso { get; set; } = string.Empty;
        public int UsuarioID { get; set; }
        public bool Movimiento { get; set; }
    }
}
