using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Entidades
{
    public class ConsultaReporteDocumentosAntiguos
    {
        public int Oficina { get; set; }
        public int TipoDocumento { get; set; }
        public string Fecha { get; set; } = string.Empty;
    }
}
