using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.DA
{
    public interface IGestionarCategoriaDA
    {
        Task<IEnumerable<Categoria>> ListarCategorias();
        Task<Categoria> ObtenerCategoria(int id);
        Task<bool> CrearCategoria(Categoria categoria);
        Task<bool> ActualizarCategoria(Categoria categoria);
        Task<bool> EliminarCategoria(int id);

    }
}
