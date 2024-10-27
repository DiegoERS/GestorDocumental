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
    public class GestionarPermisoDA:IGestionarPermisoDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarPermisoDA(GestorDocumentalContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarPermiso(Permiso permiso)
        {
            var idParameter = new SqlParameter("@pN_Id", permiso.Id);
            var nombreParameter = new SqlParameter("@pC_Nombre", permiso.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", permiso.Descripcion);
            var activoParameter = new SqlParameter("@pB_Activo", permiso.Activo);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC SC.PA_ActualizarPermiso @pN_Id, @pC_Nombre, @pC_Descripcion, @pB_Activo",
                                                                 idParameter,
                                                                 nombreParameter,
                                                                 descripcionParameter,
                                                                 activoParameter);

            return resultado > 0;
        }

        public async Task<bool> CrearPermiso(Permiso permiso)
        {
            var nombreParameter = new SqlParameter("@pC_Nombre", permiso.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", permiso.Descripcion);
            var activoParameter = new SqlParameter("@pB_Activo", permiso.Activo);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                                    "EXEC SC.PA_InsertarPermiso @pC_Nombre, @pC_Descripcion, @pB_Activo",
                                                                       nombreParameter,
                                                                       descripcionParameter,
                                                                       activoParameter);

            return resultado > 0;
        }

        public async Task<bool> EliminarPermiso(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                                        "EXEC SC.PA_EliminarPermiso @pN_Id", new SqlParameter("@pN_Id", id)
                                                                                                                                                                                                                                                                                                                                                  );

            return resultado > 0;
        }

        public async Task<IEnumerable<Permiso>> ObtenerPermisos()
        {
            var permisos = await _context.Permisos
                .FromSqlRaw("EXEC SC.PA_ListarPermisos")
                .ToListAsync();
            return permisos.Select(p => new Permiso
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Activo = p.Activo
            }).ToList();
        }

        public async Task<Permiso> obtenerPermisoPorID(int id)
        {
            try
            {
                var idParametro = new SqlParameter("@pN_Id", id);

                var permisos = await _context.Permisos
                    .FromSqlRaw("EXEC SC.PA_ListarPermisoPorID @pN_Id", idParametro)
                    .ToListAsync();

                var permisoDA = permisos.FirstOrDefault();

                if (permisoDA != null)
                {
                    return new Permiso()
                    {
                        Id = permisoDA.Id,
                        Nombre = permisoDA.Nombre,
                        Descripcion = permisoDA.Descripcion,
                        Activo = permisoDA.Activo
                    };

                }
                return new Permiso();
            }
            catch (SqlException)
            {
                return new Permiso();
            }
        }
    }
}
