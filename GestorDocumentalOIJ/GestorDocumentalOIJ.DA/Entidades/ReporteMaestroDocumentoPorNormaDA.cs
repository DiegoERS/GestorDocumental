using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Entidades
{
    public class ReporteMaestroDocumentoPorNormaDA
    {
        public string NombreNorma {  get; set; } = string.Empty;
        public string CodigoDocumento { get; set; } = string.Empty;
        public string NombreDocumento { get; set; } = string.Empty;
        public string Acceso { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;
        public string SCD { get; set; } = string.Empty;
        public int Version { get; set; }
        public string Fecha { get; set; } = string.Empty;
        public string ResumenDelCambio { get; set; } = string.Empty;
    }
}
