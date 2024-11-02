using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class ClasificacionRN
    {

        public static (bool, string) LaClasificacionEsValida(Clasificacion clasificacion)
        {
            if (clasificacion.Id < 0)
                return (false, "La clasificación no es válida debido a que el ID es igual o menor a cero.");

            if (clasificacion.Nombre is null)
                return (false, "La clasificación no es válida debido a que el Nombre es nulo.");

            if (clasificacion.Nombre.Equals(String.Empty))
                return (false, "La clasificación no es válida debido a que el Nombre está vacio.");

            if (clasificacion.Descripcion is null)
                return (false, "La clasificación no es válida debido a que la Descripción es nula.");

            if (clasificacion.Descripcion.Equals(String.Empty))
                return (false, "La clasificación no es válida debido a que la Descripción está vacia.");

            if (clasificacion.UsuarioID < 0)
                return (false, "La clasificación no es válida debido a que el ID del Usuario es igual o menor a cero.");

            if (clasificacion.OficinaID < 0)
                return (false, "La clasificación no es válida debido a que el ID de la Oficina es igual o menor a cero.");

            return (true, string.Empty);
        }

    }
}
