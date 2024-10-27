using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasificacionController : ControllerBase
    {
        private readonly IGestionarClasificacionBW _gestionarClasificacionBW;

        public ClasificacionController(IGestionarClasificacionBW gestionarClasificacionBW)
        {
            _gestionarClasificacionBW = gestionarClasificacionBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClasificacionDTO>>> ObtenerClasificaciones()
        {
            return Ok(ClasificacionDTOMapper.ConvertirListaDeClasificacionesADTO(await _gestionarClasificacionBW.ObtenerClasificaciones()));
        }

        [HttpPost]
        public async Task<ActionResult<ClasificacionDTO>> CrearClasificacion(ClasificacionDTO clasificacionDTO)
        {
            return Ok(await _gestionarClasificacionBW.CrearClasificacion(ClasificacionDTOMapper.ConvertirDTOAClasificacion(clasificacionDTO)));
        }

        [HttpPut]
        public async Task<ActionResult<ClasificacionDTO>> ActualizarClasificacion(ClasificacionDTO clasificacionDTO)
        {
            return Ok(await _gestionarClasificacionBW.ActualizarClasificacion(ClasificacionDTOMapper.ConvertirDTOAClasificacion(clasificacionDTO)));
        }

        [HttpDelete]

        public async Task<ActionResult> EliminarClasificacion(EliminarRequestDTO eliminarRequestDTO)
        {
            return Ok(await _gestionarClasificacionBW.EliminarClasificacion(EliminarRequestDTOMapper.ConvertirDTOAEliminarRequest(eliminarRequestDTO)));
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ClasificacionDTO>> ObtenerClasificacionPorId(int id)
        {
            return Ok(ClasificacionDTOMapper.ConvertirClasificacionADTO(await _gestionarClasificacionBW.ObtenerClasificacionPorId(id)));
        }
    }
}
