using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DA.Entidades;

namespace GestorDocumentalOIJ.Utility
{
    public static class ConsultaReporteDocumentosAntiguosDTOMapper
    {
        public static ConsultaReporteDocumentosAntiguosDTO ConvertirConsultaReporteDocumentosAntiguosADTO(ConsultaReporteDocumentosAntiguos consultaReporteDocumentosAntiguos)
        {
            return new ConsultaReporteDocumentosAntiguosDTO()
            {
                TipoDocumento = consultaReporteDocumentosAntiguos.TipoDocumento,
                Oficina = consultaReporteDocumentosAntiguos.Oficina,
                Fecha = consultaReporteDocumentosAntiguos.Fecha
            };
        }

        public static ConsultaReporteDocumentosAntiguos ConvertirDTOAConsultaReporteDocumentosAntiguos(ConsultaReporteDocumentosAntiguosDTO consultaReporteDocumentosAntiguosDTO)
        {
            return new ConsultaReporteDocumentosAntiguos()
            {
                TipoDocumento = consultaReporteDocumentosAntiguosDTO.TipoDocumento,
                Fecha = consultaReporteDocumentosAntiguosDTO.Fecha,
                Oficina = consultaReporteDocumentosAntiguosDTO.Oficina
            };
        }
    }
}
