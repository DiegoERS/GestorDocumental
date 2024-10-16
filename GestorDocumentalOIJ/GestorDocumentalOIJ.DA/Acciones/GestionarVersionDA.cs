using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Contexto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = GestorDocumentalOIJ.BC.Modelos.Version;

namespace GestorDocumentalOIJ.DA.Acciones
{
    public class GestionarVersionDA : IGestionarVersionDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarVersionDA(GestorDocumentalContext context)
        {
            _context = context;
        }


        public async Task<bool> ActualizarVersion(Version version)
        {
            var idParameter = new SqlParameter("@pN_Id", version.Id);
            var documentoIDParameter = new SqlParameter("@pN_DocumentoID", version.DocumentoID);
            var numeroVersionParameter = new SqlParameter("@pN_NumeroVersion", version.NumeroVersion);
            var fechaCreacionParameter = new SqlParameter("@pC_FechaCreacion", version.FechaCreacion);
            var urlVersionParameter = new SqlParameter("@pC_UrlVersion", version.urlVersion);
            var eliminadoParameter = new SqlParameter("@pB_Eliminado", version.eliminado);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", version.usuarioID);


            int resultado = await _context.Database.ExecuteSqlRawAsync(
                 "EXEC GD.PA_ActualizarVersion @pN_Id, @pN_DocumentoID, @pN_NumeroVersion, @pC_FechaCreacion, @pC_UrlVersion, @pB_Eliminado, @pN_UsuarioID",
                                                                    idParameter,
                                                                    documentoIDParameter,
                                                                    numeroVersionParameter,
                                                                    fechaCreacionParameter,
                                                                    urlVersionParameter,
                                                                    eliminadoParameter,
                                                                    usuarioIDParameter);
            return resultado > 0;
        }

        public async Task<bool> CrearVersion(Version version)
        {
            var documentoIDParameter = new SqlParameter("@pN_DocumentoID", version.DocumentoID);
            var numeroVersionParameter = new SqlParameter("@pN_NumeroVersion", version.NumeroVersion);
            var fechaCreacionParameter = new SqlParameter("@pC_FechaCreacion", version.FechaCreacion);
            var urlVersionParameter = new SqlParameter("@pC_UrlVersion", version.urlVersion);
            var eliminadoParameter = new SqlParameter("@pB_Eliminado", version.eliminado);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", version.usuarioID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                         "EXEC GD.PA_InsertarVersion @pN_DocumentoID, @pN_NumeroVersion, @pC_FechaCreacion, @pC_UrlVersion, @pB_Eliminado, @pN_UsuarioID",
                        documentoIDParameter,
                        numeroVersionParameter,
                        fechaCreacionParameter,
                        urlVersionParameter,
                         eliminadoParameter,
                         usuarioIDParameter);
            return resultado > 0;
        }

        public async Task<bool> EliminarVersion(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                            "EXEC GD.PA_EliminarVersion @pN_Id", new SqlParameter("@pN_Id", id));

            return resultado > 0;
        }

        public async Task<IEnumerable<Version>> ObtenerVersiones()
        {
            var versiones = await _context.Versiones
                .FromSqlRaw("EXEC GD.PA_ListarVersiones")
                .ToListAsync();

            return versiones.Select(v => new Version
            {
                Id = v.Id,
                DocumentoID = v.DocumentoID,
                NumeroVersion = v.NumeroVersion,
                FechaCreacion = v.FechaCreacion,
                urlVersion = v.urlVersion,
                eliminado = v.eliminado,
                usuarioID = v.usuarioID
            }).ToList();
        }

        public async Task<Version> obtenerVersionPorId(int id)
        {
            try
            {
                var idParametro = new SqlParameter("@pN_Id", id);

                var versiones = await _context.Versiones
                    .FromSqlRaw("EXEC GD.PA_ObtenerVersionPorId @pN_Id", idParametro)
                    .ToListAsync();
                var versionDA = versiones.FirstOrDefault();

                if (versionDA != null)
                {
                    return new Version()
                    {
                        Id = versionDA.Id,
                        DocumentoID = versionDA.DocumentoID,
                        NumeroVersion = versionDA.NumeroVersion,
                        FechaCreacion = versionDA.FechaCreacion,
                        urlVersion = versionDA.urlVersion,
                        eliminado = versionDA.eliminado,
                        usuarioID = versionDA.usuarioID
                    };
                }

                return new Version();
            }
            catch (SqlException)
            {
                return new Version();
            }
        }

    }
}
