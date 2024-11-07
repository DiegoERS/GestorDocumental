using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.DA.Entidades;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class ReporteMaestroDocumentosDTOMapper
    {
        public static ReporteMaestroDocumentosDTO ConvertirReporteMaestroDocumentosADTO(ReporteMaestroDocumentos reporteMaestroDocumentos)
        {
            return new ReporteMaestroDocumentosDTO()
            {
                Estado = reporteMaestroDocumentos.Estado,
                CodigoDocumento = reporteMaestroDocumentos.CodigoDocumento,
                Fecha = reporteMaestroDocumentos.Fecha,
                NombreDocumento = reporteMaestroDocumentos.NombreDocumento, 
                ResumenDelCambio = reporteMaestroDocumentos.ResumenDelCambio,
                SCD = reporteMaestroDocumentos.SCD,
                TipoDocumento = reporteMaestroDocumentos.TipoDocumento,
                Version = reporteMaestroDocumentos.Version
            };
        }

        public static ReporteMaestroDocumentos ConvertirDTOAReporteMaestroDocumentos(ReporteMaestroDocumentosDTO reporteMaestroDocumentosDTO)
        {
            return new ReporteMaestroDocumentos()
            {
                Version = reporteMaestroDocumentosDTO.Version,
                TipoDocumento = reporteMaestroDocumentosDTO.TipoDocumento,
                SCD= reporteMaestroDocumentosDTO.SCD,
                ResumenDelCambio = reporteMaestroDocumentosDTO.ResumenDelCambio,
                NombreDocumento = reporteMaestroDocumentosDTO.NombreDocumento,
                Fecha = reporteMaestroDocumentosDTO.Fecha,
                CodigoDocumento = reporteMaestroDocumentosDTO.CodigoDocumento,
                Estado = reporteMaestroDocumentosDTO.Estado
            };
        }

        public static IEnumerable<ReporteMaestroDocumentosDTO> ConvertirListaDeReporteMaestroDocumentosADTO(IEnumerable<ReporteMaestroDocumentos> reporteMaestroDocumentos)
        {
            return reporteMaestroDocumentos.Select(c => new ReporteMaestroDocumentosDTO()
            {
                CodigoDocumento =c.CodigoDocumento,
                Estado =c.Estado,
                Fecha = c.Fecha,
                NombreDocumento=c.NombreDocumento,
                ResumenDelCambio=c.ResumenDelCambio,
                SCD=c.SCD,
                TipoDocumento = c.TipoDocumento,
                Version = c.Version,
            });
        }
    }
}
