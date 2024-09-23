using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly IGestionarTipoDocumentoBW _gestionarTipoDocumentoBW;

        public TipoDocumentoController(IGestionarTipoDocumentoBW gestionarTipoDocumentoBW)
        {
            _gestionarTipoDocumentoBW = gestionarTipoDocumentoBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDocumentoDTO>>> obtenerTiposDocumentos()
        {
            return Ok(TipoDocumentoDTOMapper.ConvertirListaDeTipoDocumentosADTO(await _gestionarTipoDocumentoBW.ObtenerTipoDocumentos()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDocumentoDTO>> obtenerTipoDocumentoPorId(int id)
        {
            return Ok(TipoDocumentoDTOMapper.ConvertirTipoDocumentoADTO(await _gestionarTipoDocumentoBW.ObtenerTipoDocumentoPorId(id)));
        }

        [HttpPost]
        public async Task<ActionResult<bool>> crearTipoDocumento(TipoDocumentoDTO tipoDocumentoDTO)
        {
            return Ok(await _gestionarTipoDocumentoBW.CrearTipoDocumento(TipoDocumentoDTOMapper.ConvertirDTOATipoDocumento(tipoDocumentoDTO)));
        }

        [HttpPut]
        public async Task<ActionResult<bool>> actualizarTipoDocumento(TipoDocumentoDTO tipoDocumentoDTO)
        {
            return Ok(await _gestionarTipoDocumentoBW.ActualizarTipoDocumento(TipoDocumentoDTOMapper.ConvertirDTOATipoDocumento(tipoDocumentoDTO)));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> eliminarTipoDocumento(int id)
        {
            return Ok(await _gestionarTipoDocumentoBW.EliminarTipoDocumento(id));
        }
    }
}
