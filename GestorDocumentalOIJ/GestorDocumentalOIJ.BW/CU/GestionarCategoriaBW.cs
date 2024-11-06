using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BC.ReglasDelNegocio;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.CU
{
    public class GestionarCategoriaBW: IGestionarCategoriaBW
    {
        private readonly IGestionarCategoriaDA _gestionarCategoriaDA;

        public GestionarCategoriaBW(IGestionarCategoriaDA gestionarCategoriaDA)
        {
            _gestionarCategoriaDA = gestionarCategoriaDA;
        }

        public async Task<bool> ActualizarCategoria(Categoria categoria)
        {
            (bool esValido, string mensaje) validacion = CategoriaRN.LaCategoriaEsValida(categoria);
            if (!validacion.esValido)
                return false;

            return await _gestionarCategoriaDA.ActualizarCategoria(categoria);
        }

        public async Task<bool> CrearCategoria(Categoria categoria)
        {
            (bool esValido, string mensaje) validacion = CategoriaRN.LaCategoriaEsValida(categoria);
            if (!validacion.esValido)
                return false;

            return await _gestionarCategoriaDA.CrearCategoria(categoria);
        }

        public async Task<bool> EliminarCategoria(EliminarRequest eliminarRequest)
        {
            return await _gestionarCategoriaDA.EliminarCategoria(eliminarRequest);
        }

        public async Task<Categoria> ObtenerCategoria(int id)
        {
            return await _gestionarCategoriaDA.ObtenerCategoria(id);
        }

        public async Task<IEnumerable<Categoria>> ListarCategorias()
        {
            return await _gestionarCategoriaDA.ListarCategorias();
        }   
    }
}
