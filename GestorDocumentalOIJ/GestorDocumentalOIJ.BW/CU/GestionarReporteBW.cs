using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Entidades;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.BW.CU
{
    public class GestionarReporteBW : IGestionarReporteBW
    {
        private readonly IGestionarReporteDA _gestionarReporteDA;

        public GestionarReporteBW(IGestionarReporteDA gestionarReporteDA)
        {
            _gestionarReporteDA = gestionarReporteDA;
        }

        public async Task<IEnumerable<ReporteBitacoraDeMovimiento>> ObtenerReporteBitacoraDeMovimiento(ConsultaReporteBitacoraDeMovimiento consultaReporteBitacoraDeMovimiento)
        {
            return await _gestionarReporteDA.ObtenerReporteBitacoraDeMovimiento(consultaReporteBitacoraDeMovimiento);
        }

        public async Task<IEnumerable<ReporteControlDeVersiones>> ObtenerReporteControlDeVersiones(ConsultaReporteControlDeVersiones consultaReporteControlDeVersiones)
        {
            return await _gestionarReporteDA.ObtenerReporteControlDeVersiones(consultaReporteControlDeVersiones);
        }

        public async Task<IEnumerable<ReporteDescargaDeDocumentos>> ObtenerReporteDescargaDeDocumentos(ConsultaReporteDescargaDeDocumentos consultaReporteDescargaDeDocumentos)
        {
            return await _gestionarReporteDA.ObtenerReporteDescargaDeDocumentos(consultaReporteDescargaDeDocumentos);
        }

        public async Task<IEnumerable<ReporteDocumentosAntiguos>> ObtenerReporteDocumentosAntiguos(ConsultaReporteDocumentosAntiguos consultaReporteDocumentosAntiguos)
        {
            return await _gestionarReporteDA.ObtenerReporteDocumentosAntiguos(consultaReporteDocumentosAntiguos);
        }

        public async Task<IEnumerable<ReporteMaestroDocumentoPorNorma>> ObtenerReporteMaestroDocumentoPorNorma(ConsultaReporteMaestroDocumentoPorNorma consultaReporteMaestroDocumentoPorNorma)
        {
            return await _gestionarReporteDA.ObtenerReporteMaestroDocumentoPorNorma(consultaReporteMaestroDocumentoPorNorma);
        }

        public async Task<IEnumerable<ReporteMaestroDocumentos>> ObtenerReporteMaestroDocumentos(ConsultaReporteMaestroDocumentos consultaReporteMaestroDocumentos)
        {
            return await _gestionarReporteDA.ObtenerReporteMaestroDocumentos(consultaReporteMaestroDocumentos);
        }

        public async Task<IEnumerable<ReporteDocSinMovimiento>> ObtenerReportesDocSinMovimiento(ConsultaReportesDocSinMovimiento consultaReportesDocSinMovimiento)
        {
            return await _gestionarReporteDA.ObtenerReportesDocSinMovimiento(consultaReportesDocSinMovimiento);
        }
    }
}
