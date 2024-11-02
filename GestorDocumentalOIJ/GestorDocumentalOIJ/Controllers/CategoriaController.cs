using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IGestionarCategoriaBW _gestionarCategoriaBW;

        public CategoriaController(IGestionarCategoriaBW gestionarCategoriaBW)
        {
            _gestionarCategoriaBW = gestionarCategoriaBW;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CategoriaDTO>>> ListarCategorias()
        //{
        //    return Ok(CategoriaDTOMapper.ConvertirListaDeCategoriasADTO (await _gestionarCategoriaBW.ListarCategorias()));
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDTO>> ObtenerCategoria(int id)
        {
            return Ok(CategoriaDTOMapper.ConvertirCategoriaADTO(await _gestionarCategoriaBW.ObtenerCategoria(id)));
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CrearCategoria(CategoriaDTO categoriaDTO)
        {
            return Ok(await _gestionarCategoriaBW.CrearCategoria(CategoriaDTOMapper.ConvertirDTOACategoria(categoriaDTO)));
        }


        [HttpPut]
        public async Task<ActionResult<bool>> ActualizarCategoria(CategoriaDTO categoriaDTO)
        {
            return Ok(await _gestionarCategoriaBW.ActualizarCategoria(CategoriaDTOMapper.ConvertirDTOACategoria(categoriaDTO)));    
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> EliminarCategoria(EliminarRequestDTO eliminarRequestDTO)
        {
            return Ok(await _gestionarCategoriaBW.EliminarCategoria(EliminarRequestDTOMapper.ConvertirDTOAEliminarRequest(eliminarRequestDTO)));
        }

    }
}
