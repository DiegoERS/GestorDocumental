using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.DA.Entidades;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class ReporteMaestroDocumentoPorNormaDTOMapper
    {
        public static ReporteMaestroDocumentoPorNormaDTO ConvertirReporteMaestroDocumentoPorNormaADTO(ReporteMaestroDocumentoPorNorma reporteMaestroDocumentoPorNorma)
        {
            return new ReporteMaestroDocumentoPorNormaDTO()
            {
                Version = reporteMaestroDocumentoPorNorma.Version,
                Acceso = reporteMaestroDocumentoPorNorma.Acceso,
                SCD = reporteMaestroDocumentoPorNorma.SCD,
                TipoDocumento = reporteMaestroDocumentoPorNorma.TipoDocumento,
                ResumenDelCambio = reporteMaestroDocumentoPorNorma.ResumenDelCambio,
                NombreNorma = reporteMaestroDocumentoPorNorma.NombreNorma,
                NombreDocumento = reporteMaestroDocumentoPorNorma.NombreDocumento,
                Fecha = reporteMaestroDocumentoPorNorma.Fecha,
                CodigoDocumento = reporteMaestroDocumentoPorNorma.CodigoDocumento
            };
        }

        public static ReporteMaestroDocumentoPorNorma ConvertirDTOAReporteMaestroDocumentoPorNorma(ReporteMaestroDocumentoPorNormaDTO reporteMaestroDocumentosDTO)
        {
            return new ReporteMaestroDocumentoPorNorma()
            {
                Version = reporteMaestroDocumentosDTO.Version,
                Acceso = reporteMaestroDocumentosDTO.Acceso,
                SCD = reporteMaestroDocumentosDTO .SCD,
                TipoDocumento = reporteMaestroDocumentosDTO.TipoDocumento,
                ResumenDelCambio = reporteMaestroDocumentosDTO.ResumenDelCambio,
                NombreNorma = reporteMaestroDocumentosDTO.NombreNorma,
                NombreDocumento = reporteMaestroDocumentosDTO.NombreDocumento,
                Fecha = reporteMaestroDocumentosDTO.Fecha,
                CodigoDocumento = reporteMaestroDocumentosDTO.CodigoDocumento
            };
        }

        public static IEnumerable<ReporteMaestroDocumentoPorNormaDTO> ConvertirListaDeReporteMaestroDocumentoPorNormaADTO(IEnumerable<ReporteMaestroDocumentoPorNorma> reporteMaestroDocumentoPorNormas)
        {
            return reporteMaestroDocumentoPorNormas.Select(c => new ReporteMaestroDocumentoPorNormaDTO()
            {
                CodigoDocumento = c.CodigoDocumento,
                Acceso = c.Acceso,
                Version = c.Version,
                Fecha = c.Fecha,
                NombreDocumento = c.NombreDocumento,
                NombreNorma = c.NombreNorma,
                ResumenDelCambio = c.ResumenDelCambio,
                TipoDocumento = c.TipoDocumento,   
                SCD = c.SCD
            });
        }
    }
}
