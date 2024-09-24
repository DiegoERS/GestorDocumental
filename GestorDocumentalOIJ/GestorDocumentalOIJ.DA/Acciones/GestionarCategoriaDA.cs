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
            var idParameter = new SqlParameter("@Id", categoria.Id);
            var nombreParameter = new SqlParameter("@Nombre", categoria.Nombre);
            var descripcionParameter = new SqlParameter("@Descripcion", categoria.Descripcion);
            var eliminadoParameter = new SqlParameter("@Eliminado", categoria.Eliminado);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_ActualizarCategoria @Id, @Nombre, @Descripcion, @Eliminado",
                idParameter,
                nombreParameter,
                descripcionParameter,
                eliminadoParameter
            );

            return resultado > 0;
        }

        public async Task<bool> CrearCategoria(Categoria categoria)
        {
            var nombreParameter = new SqlParameter("@Nombre", categoria.Nombre);
            var descripcionParameter = new SqlParameter("@Descripcion", categoria.Descripcion);

            int resultado=await _context.Database.ExecuteSqlRawAsync(
                "EXEC  sp_InsertarCategoria @Nombre, @Descripcion",
                nombreParameter,
                descripcionParameter
            );

            return resultado > 0;

        }

        public async Task<bool> EliminarCategoria(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
            "EXEC sp_EliminarCategoria @Id",
            new SqlParameter("@Id", id)
        );

            return resultado > 0;

        }

        public async Task<IEnumerable<Categoria>> ListarCategorias()
        {
     
            var categorias = await _context.Categorias
                .FromSqlRaw("EXEC sp_ListarCategorias")
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
            var idParametro = new SqlParameter("@Id", id);

            var categorias = await _context.Categorias
                .FromSqlRaw("EXEC sp_ObtenerCategoriaPorId @Id", idParametro)
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
