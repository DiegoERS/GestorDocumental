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
    public class GestionarRolDA:IGestionarRolDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarRolDA(GestorDocumentalContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarRol(Rol rol)
        {
            var idParameter = new SqlParameter("@pN_Id", rol.Id);
            var nombreParameter = new SqlParameter("@pC_Nombre", rol.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", rol.Descripcion);
            var activoParameter = new SqlParameter("@pB_Activo", rol.Activo);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC SC.PA_ActualizarRol @pN_Id, @pC_Nombre, @pC_Descripcion, @pB_Activo",
                                                                   idParameter,
                                                                   nombreParameter,
                                                                   descripcionParameter,
                                                                   activoParameter);

            return resultado > 0;
        }

       
        public async Task<bool> CrearRol(Rol rol)
        {
            var nombreParameter = new SqlParameter("@pC_Nombre", rol.Nombre);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", rol.Descripcion);
            var activoParameter = new SqlParameter("@pB_Activo", rol.Activo);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC SC.PA_InsertarRol @pC_Nombre, @pC_Descripcion, @pB_Activo",
                                                               nombreParameter,
                                                               descripcionParameter,
                                                               activoParameter);
            return resultado > 0;
        }

        public async Task<bool> EliminarRol(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync( "EXEC SC.PA_EliminarRol @pN_Id", new SqlParameter("@pN_Id", id));

            return resultado > 0;
        }

        public async Task<Rol> ObtenerRolPorId(int id)
        {
            try
            {
                var idParametro = new SqlParameter("@pN_Id", id);

                var roles = await _context.Roles
                    .FromSqlRaw("EXEC SC.PA_ListarRolPorId @pN_Id", idParametro)
                    .ToListAsync();

                var rolDA = roles.FirstOrDefault();

                if (rolDA != null)
                {
                    return new Rol()
                    {
                        Id = rolDA.Id,
                        Nombre = rolDA.Nombre,
                        Descripcion = rolDA.Descripcion,
                        Activo = rolDA.Activo
                    };

                }
                return new Rol();
            }
            catch (SqlException)
            {
                return new Rol();
            }
        }

        public async Task<IEnumerable<Rol>> ObtenerRoles()
        {
            var roles = await _context.Roles
                .FromSqlRaw("EXEC SC.PA_ListarRoles")
                .ToListAsync();
            return roles.Select(r => new Rol
            {
                Id = r.Id,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion,
                Activo = r.Activo
            }).ToList();
        }

    }
}
