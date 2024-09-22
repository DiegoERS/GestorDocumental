using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class CategoriaDTOMapper
    {
        public static CategoriaDTO ConvertirCategoriaADTO(Categoria categoria)
        {
            return new CategoriaDTO()
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                Eliminado = categoria.Eliminado
            };
        }

        public static Categoria ConvertirDTOACategoria(CategoriaDTO categoriaDTO)
        {
            return new Categoria()
            {
                Id = categoriaDTO.Id,
                Nombre = categoriaDTO.Nombre,
                Descripcion = categoriaDTO.Descripcion,
                Eliminado = categoriaDTO.Eliminado
            };
        }

        public static IEnumerable<CategoriaDTO> ConvertirListaDeCategoriasADTO(IEnumerable<Categoria> categorias)
        {
            return categorias.Select(c => new CategoriaDTO()
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Eliminado = c.Eliminado
            });
        }
    }
}
