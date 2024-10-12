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
            var idParameter = new SqlParameter("@Id", subclasificacion.Id);
            var nombreParameter = new SqlParameter("@Nombre", subclasificacion.Nombre);
            var descripcionParameter = new SqlParameter("@Descripcion", subclasificacion.Descripcion);
            var eliminadoParameter = new SqlParameter("@Eliminado", subclasificacion.Eliminado);
            var idClasificacionParameter = new SqlParameter("@IdClasificacion", subclasificacion.ClasificacionID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                               "EXEC sp_ActualizarSubclasificacion @Id, @Nombre, @Descripcion, @Eliminado, @IdClasificacion",
                                              idParameter,
                                              nombreParameter,
                                              descripcionParameter,
                                              eliminadoParameter,
                                              idClasificacionParameter);

            return resultado > 0;
        }


        public async Task<bool> crearSubclasificacion(Subclasificacion subclasificacion)
        {
            var nombreParameter = new SqlParameter("@Nombre", subclasificacion.Nombre);
            var descripcionParameter = new SqlParameter("@Descripcion", subclasificacion.Descripcion);
            var idClasificacionParameter = new SqlParameter("@IdClasificacion", subclasificacion.ClasificacionID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                               "EXEC  sp_InsertarSubclasificacion @Nombre, @Descripcion, @IdClasificacion",
                                              nombreParameter,
                                              descripcionParameter,
                                              idClasificacionParameter);

            return resultado > 0;

        }


        public async Task<bool> eliminarSubclasificacion(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                           "EXEC sp_EliminarSubclasificacion @Id",
                                      new SqlParameter("@Id", id));

            return resultado > 0;
        }


        public async Task<IEnumerable<Subclasificacion>> obtenerSubclasificaciones()
        {
            var subclasificaciones = await _context.Subclasificaciones
                .FromSqlRaw("EXEC sp_ListarSubclasificaciones")
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
                var idParametro = new SqlParameter("@Id", id);

                var subclasificaciones = await _context.Subclasificaciones
                    .FromSqlRaw("EXEC sp_ObtenerSubclasificacionPorId @Id", idParametro)
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
