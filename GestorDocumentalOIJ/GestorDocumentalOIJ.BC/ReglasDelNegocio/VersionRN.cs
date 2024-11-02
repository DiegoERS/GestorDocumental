using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class VersionRN
    {
        public static (bool, string) LaVersionEsValida(Modelos.Version version)
        {
           if(version.Id < 0)
            {
                return (false, "El id es requerido.");
            }

            if (version.NumeroVersion < 0)
            {
                return (false, "El numero de version es requerido.");
            }

            if (string.IsNullOrWhiteSpace(version.urlVersion))
            {
                return (false, "La url de la version es requerida.");
            }

            if (version.usuarioID < 0)
            {
                return (false, "El usuario es requerido.");
            }

            if (string.IsNullOrWhiteSpace(version.NumeroSCD))
            {
                return (false, "El numero de SCD es requerido.");
            }

            if (string.IsNullOrWhiteSpace(version.justificacion))
            {
                return (false, "La justificacion es requerida.");
            }

            if (version.UsuarioLogID < 0)
            {
                return (false, "El usuario de bitacora es requerido.");
            }

            if (version.OficinaID < 0)
            {
                return (false, "La oficina es requerida.");
            }




            return (true, string.Empty);
        }
    }
}
