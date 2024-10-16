using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IGestionarDocumentoBW _gestionarDocumentoBW;

        public DocumentoController(IGestionarDocumentoBW gestionarDocumentoBW)
        {
            _gestionarDocumentoBW = gestionarDocumentoBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoDTO>>> ObtenerDocumentos()
        {
            return Ok(DocumentoDTOMapper.ConvertirListaDeDocumentosADTO(await _gestionarDocumentoBW.ObtenerDocumentos()));
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<DocumentoDTO>> obtenerDocumentoPorId(int id)
        {
            return Ok(DocumentoDTOMapper.ConvertirDocumentoADTO(await _gestionarDocumentoBW.obtenerDocumentoPorId(id)));
        }


        [HttpPost]

        public async Task<ActionResult<bool>> CrearDocumento(DocumentoDTO documentoDTO)
        {
            return Ok(await _gestionarDocumentoBW.CrearDocumento(DocumentoDTOMapper.ConvertirDTOADocumento(documentoDTO)));
        }

        [HttpPut]

        public async Task<ActionResult<bool>> ActualizarDocumento(DocumentoDTO documentoDTO)
        {
            return Ok(await _gestionarDocumentoBW.ActualizarDocumento(DocumentoDTOMapper.ConvertirDTOADocumento(documentoDTO)));
        }

        [HttpDelete("{id}")] 

        public async Task<ActionResult<bool>> EliminarDocumento(int id)
        {
            return Ok(await _gestionarDocumentoBW.EliminarDocumento(id));
        }

    }
}
