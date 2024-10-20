﻿using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Contexto;
using GestorDocumentalOIJ.DA.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Acciones
{
    public class GestionarDocumentoDA:IGestionarDocumentoDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarDocumentoDA(GestorDocumentalContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarDocumento(Documento documento)
        {
            var listaSerializada = JsonConvert.SerializeObject(documento.doctos);
            var idParameter = new SqlParameter("@pN_Id", documento.Id);
            var codigoParameter = new SqlParameter("@pC_Codigo", documento.Codigo);
            var asuntoParameter = new SqlParameter("@pC_Asunto", documento.Asunto);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", documento.Descripcion);
            var palabraClaveParameter = new SqlParameter("@pC_PalabraClave", documento.PalabraClave);
            var categoriaIDParameter = new SqlParameter("@pN_CategoriaID", documento.CategoriaID);
            var tipoDocumentoParameter = new SqlParameter("@pN_TipoDocumento", documento.TipoDocumento);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", documento.OficinaID);
            var vigenciaParameter = new SqlParameter("@pC_Vigencia", documento.Vigencia);
            var etapaIDParameter = new SqlParameter("@pN_EtapaID", documento.EtapaID);
            var subClasificacionIDParameter = new SqlParameter("@pN_SubClasificacionID", documento.SubClasificacionID);
            var doctosParameter = new SqlParameter("@pC_Doctos", listaSerializada);
            var activoParameter = new SqlParameter("@pB_Activo", documento.activo);
            var descargableParameter = new SqlParameter("@pB_Descargable", documento.descargable);
            var doctoIdParameter = new SqlParameter("@pN_DoctoID", documento.doctoId);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC GD.PA_ActualizarDocumento @pN_Id, @pC_Codigo, @pC_Asunto, @pC_Descripcion, @pC_PalabraClave, @pN_CategoriaID, @pN_TipoDocumento, @pN_OficinaID, @pC_Vigencia, @pN_EtapaID, @pN_DoctoID,@pN_SubClasificacionID, @pB_Activo,@pB_Descargable, @pC_Doctos",
                                                             idParameter,
                                                             codigoParameter,
                                                              asuntoParameter,
                                                              descripcionParameter,
                                                              palabraClaveParameter,
                                                              categoriaIDParameter,
                                                              tipoDocumentoParameter,
                                                              oficinaIDParameter,
                                                              vigenciaParameter,
                                                              etapaIDParameter,
                                                              doctoIdParameter,
                                                              subClasificacionIDParameter,
                                                              activoParameter,
                                                              descargableParameter,
                                                              doctosParameter);

            // Devuelve true si se afectó al menos una fila
            return resultado > 0;
        }

        public async Task<bool> CrearDocumento(Documento documento)
        {
            var listaSerializada = JsonConvert.SerializeObject(documento.doctos);
            var codigoParameter = new SqlParameter("@pC_Codigo", documento.Codigo);
            var asuntoParameter = new SqlParameter("@pC_Asunto", documento.Asunto);
            var descripcionParameter = new SqlParameter("@pC_Descripcion", documento.Descripcion);
            var palabraClaveParameter = new SqlParameter("@pC_PalabraClave", documento.PalabraClave);
            var categoriaIDParameter = new SqlParameter("@pN_CategoriaID", documento.CategoriaID);
            var tipoDocumentoParameter = new SqlParameter("@pN_TipoDocumento", documento.TipoDocumento);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", documento.OficinaID);
            var vigenciaParameter = new SqlParameter("@pC_Vigencia", documento.Vigencia);
            var etapaIDParameter = new SqlParameter("@pN_EtapaID", documento.EtapaID);
            var subClasificacionIDParameter = new SqlParameter("@pN_SubClasificacionID", documento.SubClasificacionID);
            var doctosParameter = new SqlParameter("@pC_Doctos", listaSerializada);
            var activoParameter = new SqlParameter("@pB_Activo", documento.activo);
            var descargableParameter = new SqlParameter("@pB_Descargable", documento.descargable);
            var doctoIdParameter = new SqlParameter("@pN_DoctoID", documento.doctoId);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                       "EXEC GD.PA_InsertarDocumento @pC_Codigo, @pC_Asunto, @pC_Descripcion, @pC_PalabraClave, @pN_CategoriaID, @pN_TipoDocumento, @pN_OficinaID, @pC_Vigencia, @pN_EtapaID, @pN_SubClasificacionID, @pB_Activo,@pB_Descargable,@pN_DoctoID,@pC_Doctos",
                                                                                        codigoParameter,
                                                                                        asuntoParameter,
                                                                                        descripcionParameter,
                                                                                       palabraClaveParameter,
                                                                                       categoriaIDParameter,
                                                                                       tipoDocumentoParameter,
                                                                                       oficinaIDParameter,
                                                                                       vigenciaParameter,
                                                                                       etapaIDParameter,
                                                                                       subClasificacionIDParameter,
                                                                                       activoParameter,
                                                                                       descargableParameter,
                                                                                       doctoIdParameter,
                                                                                       doctosParameter);

            return resultado > 0;
        }


        public async Task<bool> EliminarDocumento(int id)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                                            "EXEC GD.PA_EliminarDocumento @pN_Id", new SqlParameter("@pN_Id", id));

            return resultado > 0;
        }


        public async Task<IEnumerable<DocumentoExtendido>> ObtenerDocumentos()
        {
            var documentosExtendidos = new List<DocumentoExtendido>();

            // Obtiene la conexión del contexto
            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync(); // Abre la conexión

                // Define el comando para ejecutar el procedimiento almacenado
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "GD.PA_ListarDocumentos";
                    command.CommandType = CommandType.StoredProcedure; // Indica que es un procedimiento almacenado

                    // Ejecuta el comando y obtiene el lector
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        // Lee los resultados
                        while (await reader.ReadAsync())
                        {
                            // Crea una nueva instancia de DocumentoExtendido y asigna los valores
                            var documentoExtendido = new DocumentoExtendido
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                                Asunto = reader.GetString(reader.GetOrdinal("Nombre")),
                                CategoriaID = reader.GetInt32(reader.GetOrdinal("CategoriaID")),
                                TipoDocumento = reader.GetInt32(reader.GetOrdinal("TipoDocumento")),
                                OficinaID = reader.GetInt32(reader.GetOrdinal("OficinaID")),
                                Vigencia = reader.GetString(reader.GetOrdinal("Vigencia")),
                                EtapaID = reader.GetInt32(reader.GetOrdinal("EtapaID")),
                                SubClasificacionID = reader.GetInt32(reader.GetOrdinal("SubClasificacionID")),
                                doctoId = reader.GetInt32(reader.GetOrdinal("DocToID")),
                                NormaID = reader.GetInt32(reader.GetOrdinal("NormaID")),
                                VersionID = reader.GetInt32(reader.GetOrdinal("VersionID")),
                                ClasificacionID = reader.GetInt32(reader.GetOrdinal("ClasificacionID"))
                            };

                            // Agrega el objeto a la lista
                            documentosExtendidos.Add(documentoExtendido);
                        }
                    }
                }
            }

            return documentosExtendidos; // Retorna la lista de documentos extendidos
        }


        public async Task<Documento> obtenerDocumentoPorId(int id)
        {
            try
            {
                var idParametro = new SqlParameter("@pN_Id", id);

                var documentos = await _context.Documentos
                    .FromSqlRaw("EXEC GD.PA_ObtenerDocumentoPorId @pN_Id", idParametro)
                    .ToListAsync();
                var documentoDA = documentos.FirstOrDefault();

                if (documentoDA != null)
                {
                  Console.WriteLine(documentoDA.ToString());
                    return new Documento()
                    {
                        Codigo = documentoDA.Codigo,
                        Asunto = documentoDA.Asunto,
                        Descripcion = documentoDA.Descripcion,
                        PalabraClave = documentoDA.PalabraClave,
                        CategoriaID = documentoDA.CategoriaID,
                        TipoDocumento = documentoDA.TipoDocumento,
                        OficinaID = documentoDA.OficinaID,
                        Vigencia = documentoDA.Vigencia,
                        EtapaID = documentoDA.EtapaID,
                        SubClasificacionID = documentoDA.SubClasificacionID,
                        activo = documentoDA.activo,
                        descargable = documentoDA.descargable,
                        doctoId = documentoDA.doctoId,
                        doctos= JsonConvert.DeserializeObject<IEnumerable<RelacionesDoc>>(documentoDA.doctos),
                        ClasificacionID = documentoDA.ClasificacionID,
                        NormaID = documentoDA.NormaID
                    };
                }

                return new Documento();
            }
            catch (SqlException)
            {
                return new Documento();
            }
        }
    }
}
