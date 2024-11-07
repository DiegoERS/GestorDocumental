using GestorDocumentalOIJ.BW.CU;
using GestorDocumentalOIJ.BW.Interfaces.BW;
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
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ReporteBitacoraDeMovimiento(int oficinaID)
        {
            return null;
        }
        
        [HttpGet]
        [Route("ReporteControlDeVersiones")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ReporteControlDeVersiones(int oficinaID)
        {
            return null;
        }
        
        [HttpGet]
        [Route("ReporteDocumentosAntiguos")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ReporteDocumentosAntiguos(int oficinaID)
        {
            return null;
        }
        
        [HttpGet]
        [Route("ReporteMaestroDocumentoPorNorma")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ReporteMaestroDocumentoPorNorma(int oficinaID)
        {
            return null;
        }

        [HttpGet]
        [Route("ReporteMaestroDocumentos")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ReporteMaestroDocumentos(int oficinaID)
        {
            return null;
        }

        [HttpGet]
        [Route("ReporteDescargaDeDocumentos")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ReporteDescargaDeDocumentos(int oficinaID)
        {
            return null;
        }


        [HttpGet]
        [Route("ReportesDocSinMovimiento")]
        public async Task<ActionResult<IEnumerable<ReportesDocSinMovimientoDTO>>> ReportesDocSinMovimiento(ConsultaReportesDocSinMovimientoDTO consultaReportesDocSinMovimientoDTO)
        {
            return Ok(ReporteDocSinMovimientoDTOMapper.ConvertirListaDeReportesDocSinMovimientosADTO(await _gestionarReporteBW.ObtenerReportesDocSinMovimiento(ConsultaReporteDocSinMovimientoDTOMapper.ConvertirDTOAConsultaReportesDocSinMovimiento(consultaReportesDocSinMovimientoDTO))));

        }
    }
}
