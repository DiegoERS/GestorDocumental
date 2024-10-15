using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoController : ControllerBase
    {
        private readonly IGestionarDoctoBW _gestionarDoctoBW;

        public DoctoController(IGestionarDoctoBW gestionarDoctoBW)
        {
            _gestionarDoctoBW = gestionarDoctoBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctoDTO>>> ObtenerDoctos()
        {
            return Ok(DoctoDTOMapper.ConvertirListaDeDoctosADTO(await _gestionarDoctoBW.ObtenerDoctos()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctoDTO>> ObtenerDocto(int id)
        {
            return Ok(DoctoDTOMapper.ConvertirDoctoADTO(await _gestionarDoctoBW.ObtenerDocto(id)));
        }


        [HttpPost]

        public async Task<ActionResult<bool>> CrearDocto(DoctoDTO doctoDTO)
        {
            return Ok(await _gestionarDoctoBW.CrearDocto(DoctoDTOMapper.ConvertirDTOADocto(doctoDTO)));
        }

        [HttpPut]

        public async Task<ActionResult<bool>> ActualizarDocto(DoctoDTO doctoDTO)
        {
            return Ok(await _gestionarDoctoBW.ActualizarDocto(DoctoDTOMapper.ConvertirDTOADocto(doctoDTO)));
        }

        [HttpDelete("{id}")]


        public async Task<ActionResult<bool>> EliminarDocto(int id)
        {
            return Ok(await _gestionarDoctoBW.EliminarDocto(id));
        }

    }
}
