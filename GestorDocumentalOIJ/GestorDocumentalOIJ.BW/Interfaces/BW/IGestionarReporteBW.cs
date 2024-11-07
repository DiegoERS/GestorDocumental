using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DA.Entidades;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.BW.Interfaces.BW
{
    public interface IGestionarReporteBW
    {
        Task<IEnumerable<ReporteDocSinMovimiento>> ObtenerReportesDocSinMovimiento(ConsultaReportesDocSinMovimiento consultaReportesDocSinMovimiento);
        Task<IEnumerable<ReporteBitacoraDeMovimiento>> ObtenerReporteBitacoraDeMovimiento(ConsultaReporteBitacoraDeMovimiento consultaReporteBitacoraDeMovimiento);
        Task<IEnumerable<ReporteControlDeVersiones>> ObtenerReporteControlDeVersiones(ConsultaReporteControlDeVersiones consultaReporteControlDeVersiones);
        Task<IEnumerable<ReporteDescargaDeDocumentos>> ObtenerReporteDescargaDeDocumentos(ConsultaReporteDescargaDeDocumentos consultaReporteDescargaDeDocumentos);
        Task<IEnumerable<ReporteDocumentosAntiguos>> ObtenerReporteDocumentosAntiguos(ConsultaReporteDocumentosAntiguos consultaReporteDocumentosAntiguos);
        Task<IEnumerable<ReporteMaestroDocumentoPorNorma>> ObtenerReporteMaestroDocumentoPorNorma(ConsultaReporteMaestroDocumentoPorNorma consultaReporteMaestroDocumentoPorNorma);
        Task<IEnumerable<ReporteMaestroDocumentos>> ObtenerReporteMaestroDocumentos(ConsultaReporteMaestroDocumentos consultaReporteMaestroDocumentos);
    }
}
