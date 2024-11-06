using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class CategoriaRN
    {
        public static (bool, string) LaCategoriaEsValida(Categoria categoria)
        {
            if (categoria.Id < 0)
                return (false, "La categoría no es válida debido a que el ID es igual o menor a cero.");

            if (categoria.Nombre is null)
                return (false, "La categoría no es válida debido a que el Nombre es nulo.");

            if (categoria.Nombre.Equals(String.Empty))
                return (false, "La categoría no es válida debido a que el Nombre está vacio.");

            if (categoria.Descripcion is null)
                return (false, "La categoría no es válida debido a que la Descripción es nula.");

            if (categoria.Descripcion.Equals(String.Empty))
                return (false, "La categoría no es válida debido a que la Descripción está vacia.");

            if (categoria.UsuarioID < 0)
                return (false, "La categoría no es válida debido a que el ID del Usuario es igual o menor a cero.");

            if (categoria.OficinaID < 0)
                return (false, "La categoría no es válida debido a que el ID de la Oficina es igual o menor a cero.");


            return (true, string.Empty);
        }
    }

    
}
