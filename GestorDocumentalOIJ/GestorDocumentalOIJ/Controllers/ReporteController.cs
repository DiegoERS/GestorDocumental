using GestorDocumentalOIJ.BW.CU;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DA.Entidades;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : Controller
    {
        private readonly IGestionarReporteBW _gestionarReporteBW;

        public ReporteController(IGestionarReporteBW gestionarReporteBW)
        {
            _gestionarReporteBW = gestionarReporteBW;
        }

        [HttpGet]
        [Route("ReporteBitacoraDeMovimiento")]
        public async Task<ActionResult<IEnumerable<ReporteBitacoraDeMovimientoDTO>>> ReporteBitacoraDeMovimiento(ConsultaReporteBitacoraDeMovimientoDTO consultaReporteBitacoraDeMovimientoDTO)
        {
            return Ok(ReporteBitacoraDeMovimientoDTOMapper.ConvertirListaDeReporteBitacoraDeMovimientoADTO(await _gestionarReporteBW.ObtenerReporteBitacoraDeMovimiento(ConsultaReporteBitacoraDeMovimientoDTOMapper.ConvertirDTOAConsultaReporteBitacoraDeMovimiento(consultaReporteBitacoraDeMovimientoDTO))));
        }
        
        [HttpGet]
        [Route("ReporteControlDeVersiones")]
        public async Task<ActionResult<IEnumerable<ReporteControlDeVersionesDTO>>> ReporteControlDeVersiones(ConsultaReporteControlDeVersionesDTO consultaReporteControlDeVersionesDTO)
        {
            return Ok();
        }
        
        [HttpGet]
        [Route("ReporteDocumentosAntiguos")]
        public async Task<ActionResult<IEnumerable<ReporteDocumentosAntiguosDTO>>> ReporteDocumentosAntiguos(ConsultaReporteDocumentosAntiguosDTO consultaReporteDocumentosAntiguosDTO)
        {
            return Ok();
        }
        
        [HttpGet]
        [Route("ReporteMaestroDocumentoPorNorma")]
        public async Task<ActionResult<IEnumerable<ReporteMaestroDocumentoPorNormaDTO>>> ReporteMaestroDocumentoPorNorma(ConsultaReporteMaestroDocumentoPorNormaDTO consultaReporteMaestroDocumentoPorNormaDTO)
        {
            return Ok();
        }

        [HttpGet]
        [Route("ReporteMaestroDocumentos")]
        public async Task<ActionResult<IEnumerable<_ReporteMaestroDocumentosDTO>>> ReporteMaestroDocumentos(ConsultaReporteMaestroDocumentosDTO consultaReporteMaestroDocumentosDTO)
        {
            return Ok();
        }

        [HttpGet]
        [Route("ReporteDescargaDeDocumentos")]
        public async Task<ActionResult<IEnumerable<ReporteDescargaDeDocumentosDTO>>> ReporteDescargaDeDocumentos(ConsultaReporteDescargaDeDocumentosDTO consultaReporteDescargaDeDocumentosDTO)
        {
            return Ok();
        }


        [HttpGet]
        [Route("ReportesDocSinMovimiento")]
        public async Task<ActionResult<IEnumerable<ReportesDocSinMovimientoDTO>>> ReportesDocSinMovimiento(ConsultaReporteDocSinMovimientoDTO consultaReportesDocSinMovimientoDTO)
        {
            return Ok(ReporteDocSinMovimientoDTOMapper.ConvertirListaDeReportesDocSinMovimientosADTO(await _gestionarReporteBW.ObtenerReportesDocSinMovimiento(ConsultaReporteDocSinMovimientoDTOMapper.ConvertirDTOAConsultaReportesDocSinMovimiento(consultaReportesDocSinMovimientoDTO))));
        }
    }
}
