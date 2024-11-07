using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.DA.Entidades;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class ReporteDescargaDeDocumentosDTOMapper
    {
        public static ReporteDescargaDeDocumentosDTO ConvertirReporteDescargaDeDocumentosADTO(ReporteDescargaDeDocumentos reporteDescargaDeDocumentos)
        {
            return new ReporteDescargaDeDocumentosDTO()
            {
                Version = reporteDescargaDeDocumentos.Version,
                Acceso =  reporteDescargaDeDocumentos.Acceso,
                CodigoDocumento = reporteDescargaDeDocumentos.CodigoDocumento,
                Fecha = reporteDescargaDeDocumentos.Fecha,
                NombreDocumento = reporteDescargaDeDocumentos.NombreDocumento,
                OficinaResponsable = reporteDescargaDeDocumentos.OficinaResponsable
            };
        }

        public static ReporteDescargaDeDocumentos ConvertirDTOAReporteDescargaDeDocumentos(ReporteDescargaDeDocumentosDTO reporteDescargaDeDocumentosDTO)
        {
            return new ReporteDescargaDeDocumentos()
            {
                Version = reporteDescargaDeDocumentosDTO.Version,
                Acceso = reporteDescargaDeDocumentosDTO.Acceso,
                NombreDocumento = reporteDescargaDeDocumentosDTO.NombreDocumento,
                Fecha = reporteDescargaDeDocumentosDTO.Fecha,
                OficinaResponsable = reporteDescargaDeDocumentosDTO.OficinaResponsable,
                CodigoDocumento = reporteDescargaDeDocumentosDTO.CodigoDocumento
            };
        }

        public static IEnumerable<ReporteDescargaDeDocumentosDTO> ConvertirListaDeReporteDescargaDeDocumentosADTO(IEnumerable<ReporteDescargaDeDocumentos> reporteDescargaDeDocumentos)
        {
            return reporteDescargaDeDocumentos.Select(c => new ReporteDescargaDeDocumentosDTO()
            {
                CodigoDocumento = c.CodigoDocumento,
                OficinaResponsable = c.OficinaResponsable,
                NombreDocumento = c.NombreDocumento,
                Fecha = c.Fecha,
                Acceso = c.Acceso,
                Version = c.Version
            });
        }
    }
}
