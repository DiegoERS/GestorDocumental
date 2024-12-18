﻿using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Contexto;
using GestorDocumentalOIJ.DA.Entidades;
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
            var numeroVersionParameter = new SqlParameter("@pN_NumeroVersion", version.NumeroVersion);
            var urlVersionParameter = new SqlParameter("@pC_UrlVersion", version.urlVersion);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", version.usuarioID);
            var numeroSCDParameter = new SqlParameter("@pC_NumeroSCD", version.NumeroSCD);
            var justificacionParameter = new SqlParameter("@pC_Justificacion", version.justificacion);
            var DocDinamicoParameter = new SqlParameter("@pB_DocDinamico", version.DocDinamico);
            var obsoletoParameter = new SqlParameter("@pB_Obsoleto", version.Obsoleto);
            var usuarioLogIDParameter = new SqlParameter("@pN_UsuarioBitacoraID", version.UsuarioLogID);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", version.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                 "EXEC GD.PA_ActualizarVersion @pN_Id, @pN_NumeroVersion, @pC_UrlVersion, @pC_NumeroSCD,@pC_Justificacion,@pN_UsuarioID, @pB_DocDinamico,@pB_Obsoleto, @pN_UsuarioBitacoraID, @pN_OficinaID",
                                                                    idParameter,
                                                                    numeroVersionParameter,
                                                                    urlVersionParameter,
                                                                    numeroSCDParameter,
                                                                    justificacionParameter,
                                                                    usuarioIDParameter,
                                                                    DocDinamicoParameter,
                                                                    obsoletoParameter,
                                                                    usuarioLogIDParameter,
                                                                    oficinaIDParameter);
            return resultado > 0;
        }

        public async Task<bool> CrearVersion(Version version)
        {
            var documentoIDParameter = new SqlParameter("@pN_DocumentoID", version.DocumentoID);
            var numeroVersionParameter = new SqlParameter("@pN_NumeroVersion", version.NumeroVersion);
            var urlVersionParameter = new SqlParameter("@pC_UrlVersion", version.urlVersion);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", version.usuarioID);
            var numeroSCDParameter = new SqlParameter("@pC_NumeroSCD", version.NumeroSCD);
            var justificacionParameter = new SqlParameter("@pC_Justificacion", version.justificacion);
            var DocDinamicoParameter = new SqlParameter("@pB_DocDinamico", version.DocDinamico);
            var obsoletoParameter = new SqlParameter("@pB_Obsoleto", version.Obsoleto);
            var usuarioLogIDParameter = new SqlParameter("@pN_UsuarioBitacoraID", version.UsuarioLogID);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", version.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                         "EXEC GD.PA_InsertarVersion @pN_DocumentoID, @pN_NumeroVersion, @pC_UrlVersion, @pC_NumeroSCD, @pC_Justificacion,@pN_UsuarioID,@pB_DocDinamico,@pB_Obsoleto, @pN_UsuarioBitacoraID, @pN_OficinaID",
                        documentoIDParameter,
                        numeroVersionParameter,
                        urlVersionParameter,
                        numeroSCDParameter,
                        justificacionParameter,
                         usuarioIDParameter,
                         DocDinamicoParameter,
                         obsoletoParameter,
                         usuarioLogIDParameter,
                         oficinaIDParameter);
            return resultado > 0;
        }

        public async Task<bool> EliminarVersion(EliminarRequest eliminarRequest)
        {
            var idParametro = new SqlParameter("@pN_Id", eliminarRequest.ObjetoID);
            var usuarioIDParametro = new SqlParameter("@pN_UsuarioID", eliminarRequest.UsuarioID);
            var oficinaIDParametro = new SqlParameter("@pN_OficinaID", eliminarRequest.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync("EXEC GD.PA_EliminarVersion @pN_Id, @pN_UsuarioID, @pN_OficinaID", 
                                                                        idParametro,
                                                                        usuarioIDParametro,
                                                                        oficinaIDParametro);

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
                FechaCreacion = v.FechaCreacion.ToString(),
                urlVersion = v.urlVersion,
                eliminado = v.eliminado,
                usuarioID = v.usuarioID,
                DocDinamico = v.DocDinamico,
                Obsoleto = v.Obsoleto,
                NumeroSCD = v.NumeroSCD,
                justificacion = v.justificacion
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
                        FechaCreacion = versionDA.FechaCreacion.ToString(),
                        urlVersion = versionDA.urlVersion,
                        eliminado = versionDA.eliminado,
                        usuarioID = versionDA.usuarioID,
                        DocDinamico = versionDA.DocDinamico,
                        Obsoleto = versionDA.Obsoleto,
                        NumeroSCD = versionDA.NumeroSCD,
                        justificacion = versionDA.justificacion

                    };
                }

                return new Version();
            }
            catch (SqlException)
            {
                return new Version();
            }
        }

        public async Task<IEnumerable<BC.Modelos.Version>> obtenerVersionPorDocumentoId(int documentoID)
        {
         
                var idParametro = new SqlParameter("@pN_DocumentoID", documentoID);

                var versiones = await _context.Versiones
                    .FromSqlRaw("EXEC GD.PA_ListarVersionPorDocumentoID @pN_DocumentoID", idParametro)
                    .ToListAsync();

                return versiones.Select(v => new Version
                {
                    Id = v.Id,
                    DocumentoID = v.DocumentoID,
                    NumeroVersion = v.NumeroVersion,
                    FechaCreacion = v.FechaCreacion.ToString(),
                    urlVersion = v.urlVersion,
                    eliminado = v.eliminado,
                    usuarioID = v.usuarioID,
                    DocDinamico = v.DocDinamico,
                    Obsoleto = v.Obsoleto,
                    NumeroSCD = v.NumeroSCD,
                    justificacion = v.justificacion
                }).ToList();
        }

    }
}
