using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.DA.Entidades;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class ReporteDocumentosAntiguosDTOMapper
    {
        public static ReporteDocumentosAntiguosDTO ConvertirReporteDocumentosAntiguosADTO(ReporteDocumentosAntiguos reporteDocumentosAntiguos)
        {
            return new ReporteDocumentosAntiguosDTO()
            {
                Acceso = reporteDocumentosAntiguos.Acceso,
                OficinaResponsable = reporteDocumentosAntiguos.OficinaResponsable,
                CodigoDocumento = reporteDocumentosAntiguos.CodigoDocumento,
                NombreDocumento = reporteDocumentosAntiguos.NombreDocumento,
                Fecha = reporteDocumentosAntiguos.Fecha,
                Version = reporteDocumentosAntiguos.Version
            };
        }

        public static ReporteDocumentosAntiguos ConvertirDTOAReporteDocumentosAntiguos(ReporteDocumentosAntiguosDTO reporteDocumentosAntiguosDTO)
        {
            return new ReporteDocumentosAntiguos()
            {
                Version = reporteDocumentosAntiguosDTO.Version,
                Fecha = reporteDocumentosAntiguosDTO.Fecha,
                NombreDocumento = reporteDocumentosAntiguosDTO.NombreDocumento,
                CodigoDocumento = reporteDocumentosAntiguosDTO.CodigoDocumento,
                Acceso = reporteDocumentosAntiguosDTO.Acceso,
                OficinaResponsable = reporteDocumentosAntiguosDTO.OficinaResponsable
                
            };
        }

        public static IEnumerable<ReporteDocumentosAntiguosDTO> ConvertirListaDeReporteDocumentosAntiguosADTO(IEnumerable<ReporteDocumentosAntiguos> reporteDocumentosAntiguos)
        {
            return reporteDocumentosAntiguos.Select(c => new ReporteDocumentosAntiguosDTO()
            {
                CodigoDocumento = c.CodigoDocumento,
                OficinaResponsable = c.OficinaResponsable,
                NombreDocumento = c.NombreDocumento,
                Acceso = c.Acceso,
                Version = c.Version,
                Fecha = c.Fecha
            });
        }
    }
}
