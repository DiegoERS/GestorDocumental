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
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DownloadFile(string urlArchivo)
        {
            // Llama a DownloadFile para obtener el archivo en FileContentResult
            var archivo = SaveFiles.DownloadFile(urlArchivo);

            if (archivo == null)
            {
                return NotFound();
            }

            // Retorna el archivo para que el navegador lo descargue
            return archivo;
        }
    }
}
