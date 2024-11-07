using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DA.Entidades;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IGestionarReporteBW _gestionarReporteBW;

        public ReportesController(IGestionarReporteBW gestionarReporteBW)
        {
            _gestionarReporteBW = gestionarReporteBW;
        }

        [HttpGet]
        [Route("ReporteBitacoraDeMovimiento")]
        public async Task<ActionResult<IEnumerable<ReporteBitacoraDeMovimientoDTO>>> ReporteBitacoraDeMovimiento([FromQuery] ConsultaReporteBitacoraDeMovimientoDTO consultaReporteBitacoraDeMovimientoDTO)
        {
            return Ok(ReporteBitacoraDeMovimientoDTOMapper.ConvertirListaDeReporteBitacoraDeMovimientoADTO(await _gestionarReporteBW.ObtenerReporteBitacoraDeMovimiento(ConsultaReporteBitacoraDeMovimientoDTOMapper.ConvertirDTOAConsultaReporteBitacoraDeMovimiento(consultaReporteBitacoraDeMovimientoDTO))));
        }

        [HttpGet]
        [Route("ReporteControlDeVersiones")]
        public async Task<ActionResult<IEnumerable<ReporteControlDeVersionesDTO>>> ReporteControlDeVersiones([FromQuery] ConsultaReporteControlDeVersionesDTO consultaReporteControlDeVersionesDTO)
        {
            return Ok(ReporteControlDeVersionesDTOMapper.ConvertirListaDeReporteBitacoraDeMovimientoADTO(await _gestionarReporteBW.ObtenerReporteControlDeVersiones(ConsultaReporteControlDeVersionesDTOMapper.ConvertirDTOAConsultaReporteControlDeVersiones(consultaReporteControlDeVersionesDTO))));
        }

        [HttpGet]
        [Route("ReporteDocumentosAntiguos")]
        public async Task<ActionResult<IEnumerable<ReporteDocumentosAntiguosDTO>>> ReporteDocumentosAntiguos([FromQuery] ConsultaReporteDocumentosAntiguosDTO consultaReporteDocumentosAntiguosDTO)
        {
            return Ok(ReporteDocumentosAntiguosDTOMapper.ConvertirListaDeReporteDocumentosAntiguosADTO(await _gestionarReporteBW.ObtenerReporteDocumentosAntiguos(ConsultaReporteDocumentosAntiguosDTOMapper.ConvertirDTOAConsultaReporteDocumentosAntiguos(consultaReporteDocumentosAntiguosDTO))));
        }

        [HttpGet]
        [Route("ReporteMaestroDocumentoPorNorma")]
        public async Task<ActionResult<IEnumerable<ReporteMaestroDocumentoPorNormaDTO>>> ReporteMaestroDocumentoPorNorma([FromQuery] ConsultaReporteMaestroDocumentoPorNormaDTO consultaReporteMaestroDocumentoPorNormaDTO)
        {
            return Ok(ReporteMaestroDocumentoPorNormaDTOMapper.ConvertirListaDeReporteMaestroDocumentoPorNormaADTO(await _gestionarReporteBW.ObtenerReporteMaestroDocumentoPorNorma(ConsultaReporteMaestroDocumentoPorNormaDTOMapper.ConvertirDTOAConsultaReporteMaestroDocumentoPorNorma(consultaReporteMaestroDocumentoPorNormaDTO))));
        }

        [HttpGet]
        [Route("ReporteMaestroDocumentos")]
        public async Task<ActionResult<IEnumerable<ReporteMaestroDocumentosDTO>>> ReporteMaestroDocumentos([FromQuery] ConsultaReporteMaestroDocumentosDTO consultaReporteMaestroDocumentosDTO)
        {
            return Ok(ReporteMaestroDocumentosDTOMapper.ConvertirListaDeReporteMaestroDocumentosADTO(await _gestionarReporteBW.ObtenerReporteMaestroDocumentos(ConsultaReporteMaestroDocumentosDTOMapper.ConvertirDTOAConsultaReporteMaestroDocumentos(consultaReporteMaestroDocumentosDTO))));
        }

        [HttpGet]
        [Route("ReporteDescargaDeDocumentos")]
        public async Task<ActionResult<IEnumerable<ReporteDescargaDeDocumentosDTO>>> ReporteDescargaDeDocumentos([FromQuery] ConsultaReporteDescargaDeDocumentosDTO consultaReporteDescargaDeDocumentosDTO)
        {
            return Ok(ReporteDescargaDeDocumentosDTOMapper.ConvertirListaDeReporteDescargaDeDocumentosADTO(await _gestionarReporteBW.ObtenerReporteDescargaDeDocumentos(ConsultaReporteDescargaDeDocumentosDTOMapper.ConvertirDTOAConsultaReporteDescargaDeDocumentos(consultaReporteDescargaDeDocumentosDTO))));
        }


        [HttpGet]
        [Route("ReportesDocSinMovimiento")]
        public async Task<ActionResult<IEnumerable<ReportesDocSinMovimientoDTO>>> ReportesDocSinMovimiento([FromQuery] ConsultaReporteDocSinMovimientoDTO consultaReportesDocSinMovimientoDTO)
        {
            return Ok(ReporteDocSinMovimientoDTOMapper.ConvertirListaDeReportesDocSinMovimientosADTO(await _gestionarReporteBW.ObtenerReportesDocSinMovimiento(ConsultaReporteDocSinMovimientoDTOMapper.ConvertirDTOAConsultaReportesDocSinMovimiento(consultaReportesDocSinMovimientoDTO))));
        }
    }
}
