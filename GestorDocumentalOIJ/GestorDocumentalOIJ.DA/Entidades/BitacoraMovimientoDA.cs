using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Entidades
{
    public class BitacoraMovimientoDA
    {
        public int Id { get; set; }
        public int VersionID { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int UsuarioID { get; set; }
        public bool Movimiento { get; set; }
    }
}
