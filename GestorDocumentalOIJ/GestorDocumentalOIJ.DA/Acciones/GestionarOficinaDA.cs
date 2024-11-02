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
    public class GestionarOficinaDA : IGestionarOficinaDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarOficinaDA(GestorDocumentalContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarOficina(Oficina oficina)
        {
            var idParameter = new SqlParameter("@pN_Id", oficina.Id);
            var nombreParameter = new SqlParameter("@pC_Nombre", oficina.Nombre);
            var codigoOficinaParameter = new SqlParameter("@pC_CodigoOficina", oficina.CodigoOficina);
            var gestorParameter = new SqlParameter("@pB_Gestor", oficina.Gestor);
            var eliminadoParameter = new SqlParameter("@pB_Eliminado", oficina.Eliminado);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC SC.PA_ActualizarOficina @pN_Id, @pC_Nombre, @pC_CodigoOficina, @pB_Gestor, @pB_Eliminado",
                                                                  idParameter,
                                                                  nombreParameter,
                                                                  codigoOficinaParameter,
                                                                  gestorParameter,
                                                                  eliminadoParameter);

            return resultado > 0;
        }

        public async Task<bool> CrearOficina(Oficina oficina)
        {
            var nombreParameter = new SqlParameter("@pC_Nombre", oficina.Nombre);
            var codigoOficinaParameter = new SqlParameter("@pC_CodigoOficina", oficina.CodigoOficina);
            var gestorParameter = new SqlParameter("@pB_Gestor", oficina.Gestor);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                     "EXEC SC.PA_InsertarOficina @pC_Nombre, @pC_CodigoOficina, @pB_Gestor",
                                                      nombreParameter,
                                                      codigoOficinaParameter,
                                                      gestorParameter);

            return resultado > 0;
        }

        public async Task<bool> EliminarOficina(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync("EXEC SC.PA_EliminarOficina @pN_Id", new SqlParameter("@pN_Id", id)
                                                                                                                                                                                                                                                                                                                                                      );

            return resultado > 0;
        }


        public async Task<Oficina> ObtenerOficinaPorId(int id)
        {
            try
            {
                var idParametro = new SqlParameter("@pN_Id", id);

                var oficinas = await _context.Oficinas
                    .FromSqlRaw("EXEC SC.PA_ListarOficinaPorID @pN_Id", idParametro)
                    .ToListAsync();

                var oficinaDA = oficinas.FirstOrDefault();

                if (oficinaDA != null)
                {
                    return new Oficina()
                    {
                        Id = oficinaDA.Id,
                        Nombre = oficinaDA.Nombre,
                        CodigoOficina = oficinaDA.CodigoOficina,
                        Gestor = oficinaDA.Gestor,
                        Eliminado = oficinaDA.Eliminado
                    };

                }
                return new Oficina();
            }
            catch (SqlException)
            {
                return new Oficina();
            }
        }


        public async Task<IEnumerable<Oficina>> ObtenerOficinas()
        {
            var oficinas = await _context.Oficinas
                .FromSqlRaw("EXEC SC.PA_ListarOficinas")
                .ToListAsync();
            return oficinas.Select(o => new Oficina
            {
                Id = o.Id,
                Nombre = o.Nombre,
                CodigoOficina = o.CodigoOficina,
                Gestor = o.Gestor,
                Eliminado = o.Eliminado
            }).ToList();
        }

        public async Task<IEnumerable<Oficina>> ObtenerOficinasGestor()
        {
            var oficinas = await _context.Oficinas
                .FromSqlRaw("EXEC SC.PA_ListarOficinasGestor")
                .ToListAsync();
            return oficinas.Select(o => new Oficina
            {
                Id = o.Id,
                Nombre = o.Nombre,
                CodigoOficina = o.CodigoOficina,
                Gestor = o.Gestor,
                Eliminado = o.Eliminado
            }).ToList();
        }

    }

}
