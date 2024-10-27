using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Contexto;
using GestorDocumentalOIJ.DA.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Acciones
{
    public class GestionarDoctoDA : IGestionarDoctoDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarDoctoDA(GestorDocumentalContext context)
        {
            _context = context;
        }


        public async Task<bool> ActualizarDocto(Docto docto)
        {
            var idParameter = new SqlParameter("@pN_Id", docto.Id);
            var nombreParameter = new SqlParameter("@pC_Nombre", docto.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", docto.Descripcion);
            var eliminadoParameter = new SqlParameter("@pB_Eliminado", docto.Eliminado);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", docto.UsuarioID);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", docto.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                              "EXEC GD.PA_sp_ActualizarDocTo @pN_Id, @pC_Nombre, @pC_Descripcion, @pB_Eliminado,@pN_UsuarioID,@pN_OficinaID",
                                                                                         idParameter,
                                                                                         nombreParameter,
                                                                                         descripcionParameter,
                                                                                         eliminadoParameter,
                                                                                         usuarioIDParameter,
                                                                                         oficinaIDParameter);

            // Devuelve true si se afectó al menos una fila
            return resultado > 0;
        }


        public async Task<bool> CrearDocto(Docto docto)
        {
            var nombreParameter = new SqlParameter("@pC_Nombre", docto.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", docto.Descripcion);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", docto.UsuarioID);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", docto.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC  GD.PA_sp_InsertarDocTo @pC_Nombre, @pC_Descripcion,@pN_UsuarioID,@pN_OficinaID",
                                                                                    nombreParameter,
                                                                                    descripcionParameter,
                                                                                    usuarioIDParameter,
                                                                                    oficinaIDParameter);

            return resultado > 0;

        }


        public async Task<bool> EliminarDocto(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                         "EXEC GD.PA_sp_EliminarDocTo @pN_Id", new SqlParameter("@pN_Id", id));

            return resultado > 0;

        }

        public async Task<IEnumerable<Docto>> ObtenerDoctos()
        {
            var doctos = await _context.Doctos
         .FromSqlRaw("EXEC GD.PA_sp_ListarDocTos")
         .ToListAsync();
            return doctos.Select(d => new Docto
            {
                Id = d.Id,
                Nombre = d.Nombre,
                Descripcion = d.Descripcion,
                Eliminado = d.Eliminado
            }).ToList();
        }

        public async Task<Docto> ObtenerDocto(int id)
        {
            try
            {
                var idParametro = new SqlParameter("@pN_Id", id);

                var doctos = await _context.Doctos
                    .FromSqlRaw("EXEC GD.PA_sp_ObtenerDocToPorId @pN_Id", idParametro)
                    .ToListAsync();

                var doctoDA = doctos.FirstOrDefault();

                if (doctoDA != null)
                {
                    return new Docto()
                    {
                        Id = doctoDA.Id,
                        Nombre = doctoDA.Nombre,
                        Descripcion = doctoDA.Descripcion,
                        Eliminado = doctoDA.Eliminado
                    };
                }

                return new Docto();
            }
            catch (SqlException)
            {
                return new Docto();
            }
        }
    }
}
