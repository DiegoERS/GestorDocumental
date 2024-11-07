using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Entidades
{
    public class ReporteControlDeVersionesDA
    {
        public string CodigoDocumento { get; set; } = string.Empty;
        public string NombreDocumento { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;
        public string SCD { get; set; } = string.Empty;
        public int Version { get; set; }
        public DateTime Fecha { get; set; } 
        public string ResumenDelCambio { get; set; } = string.Empty;
    }
}
