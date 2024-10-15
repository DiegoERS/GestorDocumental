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
    public class GestionarClasificacionDA : IGestionarClasificacionDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarClasificacionDA(GestorDocumentalContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarClasificacion(Clasificacion clasificacion)
        {
            var idParameter = new SqlParameter("@pN_Id", clasificacion.Id);
            var nombreParameter = new SqlParameter("@pC_Nombre", clasificacion.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", clasificacion.Descripcion);
            var eliminadoParameter = new SqlParameter("@pB_Eliminado", clasificacion.Eliminado);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                               "EXEC GD.PA_ActualizarClasificacion @pN_Id, @pC_Nombre, @pC_Descripcion, @pB_Eliminado",
                                              idParameter,
                                              nombreParameter,
                                              descripcionParameter,
                                              eliminadoParameter );

            return resultado > 0;
        }

        public async Task<bool> CrearClasificacion(Clasificacion clasificacion)
        {
            var nombreParameter = new SqlParameter("@pC_Nombre", clasificacion.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", clasificacion.Descripcion);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                               "EXEC  GD.PA_InsertarClasificacion @pC_Nombre, @pC_Descripcion",
                                              nombreParameter,
                                              descripcionParameter );

            return resultado > 0;

        }

        public async Task<bool> EliminarClasificacion(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                              "EXEC GD.PA_EliminarClasificacion @pN_Id",
                                              new SqlParameter("@pN_Id", id)
                                                                                                                                                                  );

            return resultado > 0;

        }

        public async Task<IEnumerable<Clasificacion>> ObtenerClasificaciones()
        {

            var clasificaciones = await _context.Clasificaciones
                .FromSqlRaw("EXEC GD.PA_ListarClasificaciones")
                .ToListAsync();
            return clasificaciones.Select(c => new Clasificacion
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Eliminado = c.Eliminado
            }).ToList();
        }

        public async Task<Clasificacion> ObtenerClasificacionPorId(int id)
        {
            try
            {
                var idParametro = new SqlParameter("@pN_Id", id);

                var clasificaciones = await _context.Clasificaciones
                    .FromSqlRaw("EXEC GD.PA_ObtenerClasificacionPorId @pN_Id", idParametro)
                    .ToListAsync();

                var clasificacionDA = clasificaciones.FirstOrDefault();

                if (clasificacionDA != null)
                {
                    return new Clasificacion()
                    {
                        Id = clasificacionDA.Id,
                        Nombre = clasificacionDA.Nombre,
                        Descripcion = clasificacionDA.Descripcion,
                        Eliminado = clasificacionDA.Eliminado
                    };

                }
                return new Clasificacion();
            }
            catch (SqlException)
            {
                return new Clasificacion();
            }
        }
    }
}
