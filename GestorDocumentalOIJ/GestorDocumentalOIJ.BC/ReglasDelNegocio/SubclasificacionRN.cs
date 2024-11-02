using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class SubclasificacionRN
    {
        public static (bool esValido, string mensaje) LaSubclasificacionEsValida(Subclasificacion subclasificacion)
        {
            if (string.IsNullOrWhiteSpace(subclasificacion.Nombre))
                return (false, "El nombre de la subclasificación es requerido");

            if (string.IsNullOrWhiteSpace(subclasificacion.Descripcion))
                return (false, "La descripción de la subclasificación es requerida");

            if (subclasificacion.Id < 0)
                return (false, "El id de la subclasificación es requerido");

            if (subclasificacion.ClasificacionID < 0)
                return (false, "El id de la clasificación es requerido");

            if (subclasificacion.UsuarioID < 0)
                return (false, "El id del usuario es requerido");

            if (subclasificacion.OficinaID < 0)
                return (false, "El id de la oficina es requerido");

            return (true, string.Empty);
        }
    }
}
