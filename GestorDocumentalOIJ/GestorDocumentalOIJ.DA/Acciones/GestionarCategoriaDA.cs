using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Contexto;
using GestorDocumentalOIJ.DA.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Acciones
{
    public class GestionarCategoriaDA : IGestionarCategoriaDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarCategoriaDA(GestorDocumentalContext context)
        {
            _context = context;
        }
        public async Task<bool> ActualizarCategoria(Categoria categoria)
        {
            var idParameter = new SqlParameter("@pN_Id", categoria.Id);
            var nombreParameter = new SqlParameter("@pC_Nombre", categoria.Nombre);
            var descripcionParameter = new SqlParameter("@Descripcion", categoria.Descripcion);
            var eliminadoParameter = new SqlParameter("@pB_Eliminado", categoria.Eliminado);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", categoria.UsuarioID);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", categoria.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                "EXEC GD.PA_ActualizarCategoria @pN_Id, @pC_Nombre, @pC_Descripcion, @pB_Eliminado,@pN_UsuarioID,@pN_OficinaID",
                idParameter,
                nombreParameter,
                descripcionParameter,
                eliminadoParameter,
                usuarioIDParameter,
                oficinaIDParameter
            );

            return resultado > 0;
        }

        public async Task<bool> CrearCategoria(Categoria categoria)
        {
            var nombreParameter = new SqlParameter("@pC_Nombre", categoria.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", categoria.Descripcion);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", categoria.UsuarioID);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", categoria.OficinaID);

            int resultado=await _context.Database.ExecuteSqlRawAsync(
                "EXEC  GD.PA_InsertarCategoria @pC_Nombre, @pC_Descripcion,@pN_UsuarioID,@pN_OficinaID",
                nombreParameter,
                descripcionParameter,
                usuarioIDParameter,
                oficinaIDParameter
            );

            return resultado > 0;

        }

        public async Task<bool> EliminarCategoria(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
            "EXEC GD.PA_EliminarCategoria @pN_Id",
            new SqlParameter("@pN_Id", id)
        );

            return resultado > 0;

        }

        public async Task<IEnumerable<Categoria>> ListarCategorias()
        {
     
            var categorias = await _context.Categorias
                .FromSqlRaw("EXEC GD.PA_ListarCategorias")
                .ToListAsync(); 
            return categorias.Select(c => new Categoria
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Eliminado = c.Eliminado
            }).ToList();
        }

        public async Task<Categoria> ObtenerCategoria(int id)
        {
            try
            { 
            var idParametro = new SqlParameter("@pN_Id", id);

            var categorias = await _context.Categorias
                .FromSqlRaw("EXEC GD.PA_ObtenerCategoriaPorId @pN_Id", idParametro)
                .ToListAsync();

            var categoriaDA = categorias.FirstOrDefault();


            if (categoriaDA != null)
            {
                return new Categoria()
                {
                    Id = categoriaDA.Id,
                    Nombre = categoriaDA.Nombre,
                    Descripcion = categoriaDA.Descripcion,
                    Eliminado = categoriaDA.Eliminado
                };

            }

            return new Categoria();
            }
            catch (SqlException)
            {
                return new Categoria();
            }


        }
    }
}
