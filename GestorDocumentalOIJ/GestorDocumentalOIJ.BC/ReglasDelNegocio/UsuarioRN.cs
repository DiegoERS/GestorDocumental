using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class UsuarioRN
    {
        public static (bool esValido, string mensaje) ElUsuarioEsValido(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                return (false, "El nombre del usuario es requerido");

            if (string.IsNullOrWhiteSpace(usuario.Apellido))
                return (false, "El primer apellido del usuario es requerido");

            if (string.IsNullOrWhiteSpace(usuario.Correo))
                return (false, "El correo del usuario es requerido");


            if (string.IsNullOrWhiteSpace(usuario.Password))
                return (false, "La contraseña del usuario es requerida");

            if (usuario.Id < 0)
                return (false, "el ID del usuario es requerido");

            if (usuario.RolID < 0)
                return (false, "el ID del rol del usuario es requerido");

            return (true, string.Empty);
        }   
    }
}
