using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Entidades
{
    public class ConsultaReporteDescargaDeDocumentos
    {
        public int Oficina {  get; set; }
        public int Usuario {  get; set; }
        public string CodigoDocumento { get; set; } = string.Empty;
        public string NombreDocumento {  get; set; } = string.Empty;
        public string FechaInicio {  get; set; } = string.Empty;
        public string FechaFinal {  get; set; } = string.Empty;
    }
}
