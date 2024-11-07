using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.Modelos
{
    public class ConsultaReportesDocSinMovimiento
    {
        public int OficinaID { get; set; }
        public string TipoDocumento { get; set; } = string.Empty;
        public string FechaInicio { get; set; } = string.Empty;
        public string FechaFin { get; set; } = string.Empty;
    }
}
