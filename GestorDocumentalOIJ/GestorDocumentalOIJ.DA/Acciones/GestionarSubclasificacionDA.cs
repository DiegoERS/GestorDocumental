using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Contexto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Acciones
{
    public class GestionarSubclasificacionDA:IGestionarSubclasificacionDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarSubclasificacionDA(GestorDocumentalContext context)
        {
            _context = context;
        }

        public async Task<bool> actualizarSubclasificacion(Subclasificacion subclasificacion)
        {
            var idParameter = new SqlParameter("@pN_Id", subclasificacion.Id);
            var nombreParameter = new SqlParameter("@pC_Nombre", subclasificacion.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", subclasificacion.Descripcion);
            var eliminadoParameter = new SqlParameter("@pB_Eliminado", subclasificacion.Eliminado);
            var idClasificacionParameter = new SqlParameter("@pN_ClasificacionID", subclasificacion.ClasificacionID);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", subclasificacion.UsuarioID);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", subclasificacion.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                               "EXEC GD.PA_ActualizarSubclasificacion @pN_Id, @pC_Nombre, @pC_Descripcion, @pB_Eliminado, @pN_ClasificacionID, @pN_UsuarioID, @pN_OficinaID",
                                              idParameter,
                                              nombreParameter,
                                              descripcionParameter,
                                              eliminadoParameter,
                                              idClasificacionParameter,
                                              usuarioIDParameter,
                                              oficinaIDParameter);

            return resultado > 0;
        }


        public async Task<bool> crearSubclasificacion(Subclasificacion subclasificacion)
        {
            var nombreParameter = new SqlParameter("@pC_Nombre", subclasificacion.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", subclasificacion.Descripcion);
            var idClasificacionParameter = new SqlParameter("@pN_ClasificacionID", subclasificacion.ClasificacionID);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", subclasificacion.UsuarioID);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", subclasificacion.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                               "EXEC  GD.PA_InsertarSubclasificacion @pC_Nombre, @pC_Descripcion, @pN_ClasificacionID, @pN_UsuarioID, @pN_OficinaID",
                                              nombreParameter,
                                              descripcionParameter,
                                              idClasificacionParameter,
                                              usuarioIDParameter,
                                              oficinaIDParameter);

            return resultado > 0;

        }


        public async Task<bool> eliminarSubclasificacion(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                           "EXEC GD.PA_EliminarSubclasificacion @pN_Id",
                                      new SqlParameter("@pN_Id", id));

            return resultado > 0;
        }


        public async Task<IEnumerable<Subclasificacion>> obtenerSubclasificaciones()
        {
            var subclasificaciones = await _context.Subclasificaciones
                .FromSqlRaw("EXEC GD.PA_ListarSubclasificaciones")
                .ToListAsync();
            return subclasificaciones.Select(c => new Subclasificacion
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Eliminado = c.Eliminado,
                ClasificacionID = c.ClasificacionID
            }).ToList();
        }


        public async Task<Subclasificacion> obtenerSubclasificacionPorId(int id)
        {
            try
            {
                var idParametro = new SqlParameter("@pN_Id", id);

                var subclasificaciones = await _context.Subclasificaciones
                    .FromSqlRaw("EXEC GD.PA_ObtenerSubclasificacionPorId @pN_Id", idParametro)
                    .ToListAsync();

                var subclasificacionDA = subclasificaciones.FirstOrDefault();

                if (subclasificacionDA != null)
                {
                    return new Subclasificacion()
                    {
                        Id = subclasificacionDA.Id,
                        Nombre = subclasificacionDA.Nombre,
                        Descripcion = subclasificacionDA.Descripcion,
                        Eliminado = subclasificacionDA.Eliminado,
                        ClasificacionID = subclasificacionDA.ClasificacionID
                    };
                }
                return new Subclasificacion();
            }
            catch (SqlException)
            {
                return new Subclasificacion();
            }
        }

    }
}
