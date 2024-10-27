﻿using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.DTOs;
using GestorDocumentalOIJ.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDocumentalOIJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        private readonly IGestionarPermisoBW _gestionarPermisoBW;

        public PermisoController(IGestionarPermisoBW gestionarPermisoBW)
        {
            _gestionarPermisoBW = gestionarPermisoBW;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermisoDTO>>> ObtenerPermisos()
        {
            return Ok(PermisoDTOMapper.ConvertirListaDePermisosADTO(await _gestionarPermisoBW.ObtenerPermisos()));
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CrearPermiso(PermisoDTO permisoDTO)
        {
            return Ok(await _gestionarPermisoBW.CrearPermiso(PermisoDTOMapper.ConvertirDTOAPermiso(permisoDTO)));
        }

        [HttpPut]

        public async Task<ActionResult<bool>> ActualizarPermiso(PermisoDTO permisoDTO)
        {
            return Ok(await _gestionarPermisoBW.ActualizarPermiso(PermisoDTOMapper.ConvertirDTOAPermiso(permisoDTO)));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> EliminarPermiso(int id)
        {
            return Ok(await _gestionarPermisoBW.EliminarPermiso(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PermisoDTO>> obtenerPermisoPorID(int id)
        {
            return Ok(PermisoDTOMapper.ConvertirPermisoADTO(await _gestionarPermisoBW.obtenerPermisoPorID(id)));
        }

        [HttpPost("AsignarPermisoARol")]
        public async Task<ActionResult<bool>> AsignarPermisoARol(int permisoID, int rolID)
        {
            return Ok(await _gestionarPermisoBW.AsignarPermisoARol(permisoID, rolID));
        }

        [HttpPost("RemoverPermisoARol")]
        public async Task<ActionResult<bool>> RemoverPermisoARol(int permisoID, int rolID)
        {
            return Ok(await _gestionarPermisoBW.RemoverPermisoARol(permisoID, rolID));
        }

        [HttpPost("AsignarPermisoAOficina")]
        public async Task<ActionResult<bool>> AsignarPermisoAOficina(int permisoID, int oficinaID)
        {
            return Ok(await _gestionarPermisoBW.AsignarPermisoAOficina(permisoID, oficinaID));
        }

        [HttpPost("RemoverPermisoAOficina")]
        public async Task<ActionResult<bool>> RemoverPermisoAOficina(int permisoID, int oficinaID)
        {
            return Ok(await _gestionarPermisoBW.RemoverPermisoAOficina(permisoID, oficinaID));
        }

    }
}
