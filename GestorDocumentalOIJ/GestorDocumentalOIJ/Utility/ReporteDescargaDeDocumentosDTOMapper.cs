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
                FechaIngreso = reporteDescargaDeDocumentos.FechaIngreso,
                NombreDocumento = reporteDescargaDeDocumentos.NombreDocumento,
                OficinaResponsable = reporteDescargaDeDocumentos.OficinaResponsable,
                Descargas = reporteDescargaDeDocumentos.Descargas,
                Visualizaciones = reporteDescargaDeDocumentos.Visualizaciones
            };
        }

        public static ReporteDescargaDeDocumentos ConvertirDTOAReporteDescargaDeDocumentos(ReporteDescargaDeDocumentosDTO reporteDescargaDeDocumentosDTO)
        {
            return new ReporteDescargaDeDocumentos()
            {
                Version = reporteDescargaDeDocumentosDTO.Version,
                Acceso = reporteDescargaDeDocumentosDTO.Acceso,
                NombreDocumento = reporteDescargaDeDocumentosDTO.NombreDocumento,
                FechaIngreso = reporteDescargaDeDocumentosDTO.FechaIngreso,
                OficinaResponsable = reporteDescargaDeDocumentosDTO.OficinaResponsable,
                CodigoDocumento = reporteDescargaDeDocumentosDTO.CodigoDocumento,
                Visualizaciones = reporteDescargaDeDocumentosDTO.Visualizaciones,
                Descargas = reporteDescargaDeDocumentosDTO.Descargas
            };
        }

        public static IEnumerable<ReporteDescargaDeDocumentosDTO> ConvertirListaDeReporteDescargaDeDocumentosADTO(IEnumerable<ReporteDescargaDeDocumentos> reporteDescargaDeDocumentos)
        {
            return reporteDescargaDeDocumentos.Select(c => new ReporteDescargaDeDocumentosDTO()
            {
                CodigoDocumento = c.CodigoDocumento,
                OficinaResponsable = c.OficinaResponsable,
                NombreDocumento = c.NombreDocumento,
                FechaIngreso = c.FechaIngreso,
                Acceso = c.Acceso,
                Version = c.Version,
                Descargas = c.Descargas,
                Visualizaciones = c.Visualizaciones
            });
        }
    }
}
