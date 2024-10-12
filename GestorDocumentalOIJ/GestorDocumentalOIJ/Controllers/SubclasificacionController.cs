using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubclasificacionController : ControllerBase
    {

        private readonly IGestionarSubclasificacionBW _gestionarSubclasificacionBW;

        public SubclasificacionController(IGestionarSubclasificacionBW gestionarSubclasificacionBW)
        {
            _gestionarSubclasificacionBW = gestionarSubclasificacionBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubclasificacionDTO>>> ListarSubclasificaciones()
        {
            return Ok(SubclasificacionDTOMapper.ConvertirListaDeSubclasificacionesADTO(await _gestionarSubclasificacionBW.obtenerSubclasificaciones()));
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<SubclasificacionDTO>> ObtenerSubclasificacion(int id)
        {
            return Ok(SubclasificacionDTOMapper.ConvertirSubclasificacionADTO(await _gestionarSubclasificacionBW.obtenerSubclasificacionPorId(id)));
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CrearSubclasificacion(SubclasificacionDTO subclasificacionDTO)
        {
            return Ok(await _gestionarSubclasificacionBW.crearSubclasificacion(SubclasificacionDTOMapper.ConvertirDTOASubclasificacion(subclasificacionDTO)));
        }

        [HttpPut]
        public async Task<ActionResult<bool>> ActualizarSubclasificacion(SubclasificacionDTO subclasificacionDTO)
        {
            return Ok(await _gestionarSubclasificacionBW.actualizarSubclasificacion(SubclasificacionDTOMapper.ConvertirDTOASubclasificacion(subclasificacionDTO)));
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> EliminarSubclasificacion(int id)
        {
            return Ok(await _gestionarSubclasificacionBW.eliminarSubclasificacion(id));
        }
    }
}
