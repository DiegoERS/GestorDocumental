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
    public class GestionarDocumentoDA:IGestionarDocumentoDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarDocumentoDA(GestorDocumentalContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarDocumento(Documento documento)
        {
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
            var doctosParameter = new SqlParameter("@pC_Doctos", documento.Doctos);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC GD.PA_ActualizarDocumento @pC_Codigo, @pC_Asunto, @pC_Descripcion, @pC_PalabraClave, @pN_CategoriaID, @pN_TipoDocumento, @pN_OficinaID, @pC_Vigencia, @pN_EtapaID, @pN_SubClasificacionID, @pC_Doctos",
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
                                                              doctosParameter);

            // Devuelve true si se afectó al menos una fila
            return resultado > 0;
        }

        public async Task<bool> CrearDocumento(Documento documento)
        {
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
            var doctosParameter = new SqlParameter("@pC_Doctos", documento.Doctos);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                                            "EXEC GD.PA_InsertarDocumento @pC_Codigo, @pC_Asunto, @pC_Descripcion, @pC_PalabraClave, @pN_CategoriaID, @pN_TipoDocumento, @pN_OficinaID, @pC_Vigencia, @pN_EtapaID, @pN_SubClasificacionID, @pC_Doctos",
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
                                                                                       doctosParameter);

            return resultado > 0;
        }


        public async Task<bool> EliminarDocumento(string codigo)
        {
            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                                            "EXEC GD.PA_EliminarDocumento @pC_Codigo", new SqlParameter("@pC_Codigo", codigo));

            return resultado > 0;
        }


        public async Task<IEnumerable<Documento>> ObtenerDocumentos()
        {
            var documentos = await _context.Documentos
                .FromSqlRaw("EXEC GD.PA_ListarDocumentos")
                .ToListAsync();

            return documentos.Select(d => new Documento
            {
                Codigo = d.Codigo,
                Asunto = d.Asunto,
                Descripcion = d.Descripcion,
                PalabraClave = d.PalabraClave,
                CategoriaID = d.CategoriaID,
                TipoDocumento = d.TipoDocumento,
                OficinaID = d.OficinaID,
                Vigencia = d.Vigencia,
                EtapaID = d.EtapaID,
                SubClasificacionID = d.SubClasificacionID,
                Doctos = d.Doctos
            }).ToList();
        }


        public async Task<Documento> ObtenerDocumentoPorCodigo(string codigo)
        {
            try
            {
                var codigoParametro = new SqlParameter("@Codigo", codigo);

                var documentos = await _context.Documentos
                    .FromSqlRaw("EXEC GD.PA_ObtenerDocumentoPorCodigo @Codigo", codigoParametro)
                    .ToListAsync();
                var documentoDA = documentos.FirstOrDefault();

                if (documentoDA != null)
                {
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
                        Doctos = documentoDA.Doctos
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
