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
                Eliminado = categoria.Eliminado,
                UsuarioID = categoria.UsuarioID,
                OficinaID = categoria.OficinaID
            };
        }

        public static Categoria ConvertirDTOACategoria(CategoriaDTO categoriaDTO)
        {
            return new Categoria()
            {
                Id = categoriaDTO.Id,
                Nombre = categoriaDTO.Nombre,
                Descripcion = categoriaDTO.Descripcion,
                Eliminado = categoriaDTO.Eliminado,
                UsuarioID = categoriaDTO.UsuarioID,
                OficinaID = categoriaDTO.OficinaID
            };
        }

        public static IEnumerable<CategoriaDTO> ConvertirListaDeCategoriasADTO(IEnumerable<Categoria> categorias)
        {
            return categorias.Select(c => new CategoriaDTO()
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Eliminado = c.Eliminado,
                UsuarioID = c.UsuarioID,
                OficinaID = c.OficinaID
            });
        }
    }
}
