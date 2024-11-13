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
            return Ok(ReporteControlDeVersionesDTOMapper.ConvertirListaDeReporteBitacoraDeMovimientoADTO(await _gestionarReporteBW.ObtenerReporteControlDeVersiones(ConsultaReporteControlDeVersionesDTOMapper.ConvertirDTOAConsultaReporteControlDeVersiones(consultaReporteControlDeVersionesDTO))));
        }
        
        [HttpGet]
        [Route("ReporteDocumentosAntiguos")]
        public async Task<ActionResult<IEnumerable<ReporteDocumentosAntiguosDTO>>> ReporteDocumentosAntiguos(ConsultaReporteDocumentosAntiguosDTO consultaReporteDocumentosAntiguosDTO)
        {
            return Ok(ReporteDocumentosAntiguosDTOMapper.ConvertirListaDeReporteDocumentosAntiguosADTO(await _gestionarReporteBW.ObtenerReporteDocumentosAntiguos(ConsultaReporteDocumentosAntiguosDTOMapper.ConvertirDTOAConsultaReporteDocumentosAntiguos(consultaReporteDocumentosAntiguosDTO))));
        }
        
        [HttpGet]
        [Route("ReporteMaestroDocumentoPorNorma")]
        public async Task<ActionResult<IEnumerable<ReporteMaestroDocumentoPorNormaDTO>>> ReporteMaestroDocumentoPorNorma(ConsultaReporteMaestroDocumentoPorNormaDTO consultaReporteMaestroDocumentoPorNormaDTO)
        {
            return Ok(ReporteMaestroDocumentoPorNormaDTOMapper.ConvertirListaDeReporteMaestroDocumentoPorNormaADTO(await _gestionarReporteBW.ObtenerReporteMaestroDocumentoPorNorma(ConsultaReporteMaestroDocumentoPorNormaDTOMapper.ConvertirDTOAConsultaReporteMaestroDocumentoPorNorma(consultaReporteMaestroDocumentoPorNormaDTO))));
        }

        [HttpGet]
        [Route("ReporteMaestroDocumentos")]
        public async Task<ActionResult<IEnumerable<ReporteMaestroDocumentosDTO>>> ReporteMaestroDocumentos(ConsultaReporteMaestroDocumentosDTO consultaReporteMaestroDocumentosDTO)
        {
            return Ok(ReporteMaestroDocumentosDTOMapper.ConvertirListaDeReporteMaestroDocumentosADTO(await _gestionarReporteBW.ObtenerReporteMaestroDocumentos(ConsultaReporteMaestroDocumentosDTOMapper.ConvertirDTOAConsultaReporteMaestroDocumentos(consultaReporteMaestroDocumentosDTO))));
        }

        [HttpGet]
        [Route("ReporteDescargaDeDocumentos")]
        public async Task<ActionResult<IEnumerable<ReporteDescargaDeDocumentosDTO>>> ReporteDescargaDeDocumentos(ConsultaReporteDescargaDeDocumentosDTO consultaReporteDescargaDeDocumentosDTO)
        {
            return Ok(ReporteDescargaDeDocumentosDTOMapper.ConvertirListaDeReporteDescargaDeDocumentosADTO(await _gestionarReporteBW.ObtenerReporteDescargaDeDocumentos(ConsultaReporteDescargaDeDocumentosDTOMapper.ConvertirDTOAConsultaReporteDescargaDeDocumentos(consultaReporteDescargaDeDocumentosDTO))));
        }


        [HttpGet]
        [Route("ReportesDocSinMovimiento")]
        public async Task<ActionResult<IEnumerable<ReportesDocSinMovimientoDTO>>> ReportesDocSinMovimiento(ConsultaReporteDocSinMovimientoDTO consultaReportesDocSinMovimientoDTO)
        {
            return Ok(ReporteDocSinMovimientoDTOMapper.ConvertirListaDeReportesDocSinMovimientosADTO(await _gestionarReporteBW.ObtenerReportesDocSinMovimiento(ConsultaReporteDocSinMovimientoDTOMapper.ConvertirDTOAConsultaReportesDocSinMovimiento(consultaReportesDocSinMovimientoDTO))));
        }
    }
}
