using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Entidades
{
    public class ReporteBitacoraDeMovimientoDA
    {
        public int Version { get; set; }
        public string NombreDocumento { get; set; } = string.Empty;
        public string CodigoDocumento { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty;
        public string Acceso { get; set; } = string.Empty;
        public string Movimiento { get; set; } = string.Empty;
        public string OficinaResponsable { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
    }
}
