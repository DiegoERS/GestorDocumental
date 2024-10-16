﻿using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private readonly IGestionarVersionBW _gestionarVersionBW;

        public VersionController(IGestionarVersionBW gestionarVersionBW)
        {
            _gestionarVersionBW = gestionarVersionBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VersionDTO>>> ObtenerVersiones()
        {
            return Ok(VersionDTOMapper.ConvertirListaDeVersionesADTO(await _gestionarVersionBW.ObtenerVersiones()));
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<VersionDTO>> obtenerVersionPorId(int id)
        {
            return Ok(VersionDTOMapper.ConvertirVersionADTO(await _gestionarVersionBW.ObtenerVersionPorId(id)));
        }

        [HttpPost]

        public async Task<ActionResult<bool>> CrearVersion(VersionDTO versionDTO)
        {
            string rutaArchivo = await SaveFiles.SaveFile(versionDTO.archivo);
            return Ok(await _gestionarVersionBW.CrearVersion(VersionDTOMapper.ConvertirDTOAVersion(versionDTO,rutaArchivo)));
        }

        [HttpPut]
        public async Task<ActionResult<bool>> ActualizarVersion(VersionDTO versionDTO)
        {
            string rutaArchivo = await SaveFiles.SaveFile(versionDTO.archivo);
            return Ok(await _gestionarVersionBW.ActualizarVersion(VersionDTOMapper.ConvertirDTOAVersion(versionDTO, rutaArchivo)));
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> EliminarVersion(int id)
        {
            return Ok(await _gestionarVersionBW.EliminarVersion(id));
        }
    }
}
