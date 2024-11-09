using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Entidades
{
    public class ConsultaReporteControlDeVersionesDTO
    {
        public int Oficina { get; set; }
        public string CodigoDocumento {  get; set; } = string.Empty;
        public string NombreDocumento { get; set; } = string.Empty;
        public int TipoDocumento { get; set; }
    }
}
