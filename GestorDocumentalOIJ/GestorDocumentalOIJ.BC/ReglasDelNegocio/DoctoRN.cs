using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class DoctoRN
    {
        public static (bool, string) ElDoctoEsValido(Docto docto)
        {
            if (docto.Id < 0)
                return (false, "El documento no es válido debido a que el ID es igual o menor a cero.");

            if (docto.Nombre is null)
                return (false, "El documento no es válido debido a que el Nombre es nulo.");

            if (docto.Nombre.Equals(String.Empty))
                return (false, "El documento no es válido debido a que el Nombre está vacio.");

            if (docto.Descripcion is null)
                return (false, "El documento no es válido debido a que la Descripción es nula.");

            if (docto.Descripcion.Equals(String.Empty))
                return (false, "El documento no es válido debido a que la Descripción está vacia.");

            if (docto.UsuarioID < 0)
                return (false, "El documento no es válido debido a que el ID del Usuario es igual o menor a cero.");

            if (docto.OficinaID < 0)
                return (false, "El documento no es válido debido a que el ID de la Oficina es igual o menor a cero.");

            return (true, string.Empty);
        }   
    }
}
