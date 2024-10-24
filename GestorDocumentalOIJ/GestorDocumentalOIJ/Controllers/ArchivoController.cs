using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoController : ControllerBase
    {

        [HttpGet("{urlArchivo}")]

        public  ActionResult<IFormFile> obtenerArchivoPorUrl(string urlArchivo)
        {
            return Ok(SaveFiles.GetIFormFile(urlArchivo));
        }
    }
}
