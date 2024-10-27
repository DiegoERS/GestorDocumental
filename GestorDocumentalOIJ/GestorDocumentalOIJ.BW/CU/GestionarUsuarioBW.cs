﻿using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.CU
{
    public class GestionarUsuarioBW: IGestionarUsuarioBW
    {
        private readonly IGestionarUsuarioDA _gestionarUsuarioDA;

        public GestionarUsuarioBW(IGestionarUsuarioDA gestionarUsuarioDA)
        {
            _gestionarUsuarioDA = gestionarUsuarioDA;
        }

        public async Task<bool> ActualizarUsuario(Usuario usuario)
        {
            return await _gestionarUsuarioDA.ActualizarUsuario(usuario);
        }

        public async Task<bool> Autenticar(string correo, string password)
        {
            return await _gestionarUsuarioDA.Autenticar(correo, password);
        }

        public async Task<bool> CrearUsuario(Usuario usuario)
        {
            return await _gestionarUsuarioDA.CrearUsuario(usuario);
        }


        public async Task<bool> EliminarUsuario(int idUsuario)
        {
            return await _gestionarUsuarioDA.EliminarUsuario(idUsuario);
        }


        public async Task<Usuario> ObtenerUsuarioPorId(int idUsuario)
        {
            return await _gestionarUsuarioDA.ObtenerUsuarioPorId(idUsuario);
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuarios()
        {
            return await _gestionarUsuarioDA.ObtenerUsuarios();
        }
    }
}
