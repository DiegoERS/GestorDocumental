using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Contexto;
using GestorDocumentalOIJ.DA.Entidades;
using GestorDocumentalOIJ.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestorDocumentalOIJ.DA.Acciones
{
    public class GestionarReporteDA : IGestionarReporteDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarReporteDA(GestorDocumentalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReporteBitacoraDeMovimiento>> ObtenerReporteBitacoraDeMovimiento(ConsultaReporteBitacoraDeMovimiento consultaReporteBitacoraDeMovimiento)
        {
            var codigoDocParameter = new SqlParameter("@pC_CodigoDocumento", consultaReporteBitacoraDeMovimiento.CodigoDocumento);
            var nombreDocumentoParameter = new SqlParameter("@pC_NombreDocumento", consultaReporteBitacoraDeMovimiento.NombreDocumento);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", consultaReporteBitacoraDeMovimiento.UsuarioID);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", consultaReporteBitacoraDeMovimiento.OficinaID);
            var fechaFinParameter = new SqlParameter("@pF_FechaFinal", consultaReporteBitacoraDeMovimiento.FechaFin);
            var fechaInicioParameter = new SqlParameter("@pF_FechaInicio", consultaReporteBitacoraDeMovimiento.FechaInicio);

            var documentosBitacoraDeMovimiento = await _context.reporteReporteBitacoraDeMovimiento
                .FromSqlRaw("EXEC GD.PA_ReporteBitacoraDeMovimiento @pC_CodigoDocumento, @pC_NombreDocumento, @pN_UsuarioID, @pN_OficinaID, @pF_FechaFinal,@pF_FechaInicio",
                                codigoDocParameter,
                                nombreDocumentoParameter,
                                usuarioIDParameter,
                                oficinaIDParameter,
                                fechaFinParameter,
                                fechaInicioParameter)
                .ToListAsync();
            return documentosBitacoraDeMovimiento.Select(c => new ReporteBitacoraDeMovimiento
            {
                OficinaResponsable = c.OficinaResponsable,
                NombreDocumento = c.NombreDocumento,
                Acceso = c.Acceso,
                CodigoDocumento = c.CodigoDocumento,
                Fecha = c.Fecha,
                Movimiento = c.Movimiento,
                Usuario = c.Usuario,
                Version = c.Version
            }).ToList();
        }

        public async Task<IEnumerable<ReporteControlDeVersiones>> ObtenerReporteControlDeVersiones(ConsultaReporteControlDeVersiones consultaReporteControlDeVersiones)
        {
            var codigoDocParameter = new SqlParameter("@pC_CodigoDocumento", consultaReporteControlDeVersiones.CodigoDocumento);
            var nombreDocumentoParameter = new SqlParameter("@pC_NombreDocumento", consultaReporteControlDeVersiones.NombreDocumento);
            var tipoDocParameter = new SqlParameter("@pN_TipoDocumento", consultaReporteControlDeVersiones.TipoDocumento);

            var documentosReporteControlDeVersiones = await _context.reporteReporteControlDeVersiones
                .FromSqlRaw("EXEC GD.PA_ReporteControlDeVersiones @pC_CodigoDocumento, @pC_NombreDocumento, @pN_TipoDocumento",
                                codigoDocParameter,
                                nombreDocumentoParameter,
                                tipoDocParameter)
                .ToListAsync();
            return documentosReporteControlDeVersiones.Select(c => new ReporteControlDeVersiones
            {
                TipoDocumento = c.TipoDocumento,
                CodigoDocumento = c.CodigoDocumento,
                Fecha = c.Fecha,
                NombreDocumento = c.NombreDocumento,
                ResumenDelCambio = c.ResumenDelCambio,
                SCD = c.SCD,
                Version = c.Version
            }).ToList();
        }

        public async Task<IEnumerable<ReporteDescargaDeDocumentos>> ObtenerReporteDescargaDeDocumentos(ConsultaReporteDescargaDeDocumentos consultaReporteDescargaDeDocumentos)
        {
            var codigoDocParameter = new SqlParameter("@pC_CodigoDocumento", consultaReporteDescargaDeDocumentos.CodigoDocumento);
            var nombreDocumentoParameter = new SqlParameter("@pC_NombreDocumento", consultaReporteDescargaDeDocumentos.NombreDocumento);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", consultaReporteDescargaDeDocumentos.Usuario);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", consultaReporteDescargaDeDocumentos.Oficina);
            var fechaFinParameter = new SqlParameter("@pF_FechaFinal", consultaReporteDescargaDeDocumentos.FechaFinal);
            var fechaInicioParameter = new SqlParameter("@pF_FechaInicio", consultaReporteDescargaDeDocumentos.FechaInicio);

            var documentosReporteDescargaDeDocumentos = await _context.reporteReporteDescargaDeDocumentos
                .FromSqlRaw("EXEC GD.PA_ReporteDescargaDeDocumentos @pN_OficinaID, @pN_UsuarioID, @pC_CodigoDocumento, @pC_NombreDocumento, @pF_FechaInicio,@pF_FechaFinal",
                                oficinaIDParameter,
                                usuarioIDParameter,
                                codigoDocParameter,
                                nombreDocumentoParameter,
                                fechaInicioParameter,
                                fechaFinParameter)
                .ToListAsync();
            return documentosReporteDescargaDeDocumentos.Select(c => new ReporteDescargaDeDocumentos
            {
                Acceso = c.Acceso, 
                CodigoDocumento = c.CodigoDocumento,
                Fecha = c.Fecha,
                NombreDocumento = c.NombreDocumento,
                OficinaResponsable = c.OficinaResponsable,
                Version = c.Version
                
            }).ToList();
        }

        public async Task<IEnumerable<ReporteDocumentosAntiguos>> ObtenerReporteDocumentosAntiguos(ConsultaReporteDocumentosAntiguos consultaReporteDocumentosAntiguos)
        {
            var fechaParameter = new SqlParameter("@pF_Fecha", consultaReporteDocumentosAntiguos.Fecha);
            var tipoDocParameter = new SqlParameter("@pN_TipoDocumento", consultaReporteDocumentosAntiguos.TipoDocumento);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", consultaReporteDocumentosAntiguos.Oficina);

            var documentosReporteDocumentosAntiguos = await _context.reporteReporteDocumentosAntiguos
                .FromSqlRaw("EXEC GD.PA_ReporteDocumentosAntiguos @pN_OficinaID, @pN_TipoDocumento, @pF_Fecha",
                                oficinaIDParameter,
                                tipoDocParameter,
                                fechaParameter)
                .ToListAsync();
            return documentosReporteDocumentosAntiguos.Select(c => new ReporteDocumentosAntiguos
            {
                Fecha = c.Fecha,
                Version = c.Version,
                OficinaResponsable = c.OficinaResponsable,
                NombreDocumento = c.NombreDocumento,
                CodigoDocumento = c.CodigoDocumento,
                Acceso = c.Acceso
               
            }).ToList();
        }

        public async Task<IEnumerable<ReporteMaestroDocumentoPorNorma>> ObtenerReporteMaestroDocumentoPorNorma(ConsultaReporteMaestroDocumentoPorNorma consultaReporteMaestroDocumentoPorNorma)
        {
            var normaParameter = new SqlParameter("@pN_Norma", consultaReporteMaestroDocumentoPorNorma.Norma);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", consultaReporteMaestroDocumentoPorNorma.Oficina);
            var categoriaParameter = new SqlParameter("@pN_Categoria", consultaReporteMaestroDocumentoPorNorma.Categoria);
            var tipoDocParameter = new SqlParameter("@pN_TipoDocumento", consultaReporteMaestroDocumentoPorNorma.TipoDocumento);

            var documentosReporteMaestroDocumentoPorNorma = await _context.reporteReporteMaestroDocumentoPorNorma
                .FromSqlRaw("EXEC GD.PA_ReporteMaestroDocumentoPorNorma @pN_OficinaID, @pN_TipoDocumento, @pN_Categoria, @pN_Norma",
                                normaParameter,
                                oficinaIDParameter,
                                categoriaParameter,
                                tipoDocParameter)
                .ToListAsync();
            return documentosReporteMaestroDocumentoPorNorma.Select(c => new ReporteMaestroDocumentoPorNorma
            {
                TipoDocumento = c.TipoDocumento,
                Acceso = c.Acceso,
                CodigoDocumento = c.CodigoDocumento,
                NombreDocumento = c.NombreDocumento,
                Version = c.Version,
                Fecha = c.Fecha,
                NombreNorma = c.NombreNorma,
                ResumenDelCambio = c.ResumenDelCambio,
                SCD = c.SCD
            }).ToList();
        }

        public async Task<IEnumerable<ReporteMaestroDocumentos>> ObtenerReporteMaestroDocumentos(ConsultaReporteMaestroDocumentos consultaReporteMaestroDocumentos)
        {
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", consultaReporteMaestroDocumentos.Oficina);
            var tipoDocParameter = new SqlParameter("@pN_TipoDocumento", consultaReporteMaestroDocumentos.TipoDocumento);

            var documentosReporteMaestroDocumentos = await _context.reporteReporteMaestroDocumentos
                .FromSqlRaw("EXEC GD.PA_ReporteMaestroDocumentos @pN_OficinaID, @pN_TipoDocumento",
                                oficinaIDParameter,
                                tipoDocParameter)
                .ToListAsync();
            return documentosReporteMaestroDocumentos.Select(c => new ReporteMaestroDocumentos
            {
                SCD = c.SCD,
                ResumenDelCambio= c.ResumenDelCambio,
                NombreDocumento = c.NombreDocumento,
                Fecha = c.Fecha,
                CodigoDocumento = c.CodigoDocumento,
                Estado = c.Estado,
                TipoDocumento = c.TipoDocumento,
                Version = c.Version
            }).ToList();
        }

        public async Task<IEnumerable<ReporteDocSinMovimiento>> ObtenerReportesDocSinMovimiento(ConsultaReportesDocSinMovimiento consultaReportesDocSinMovimiento)
        {
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", consultaReportesDocSinMovimiento.OficinaID);
            var tipoDocumentoParameter = new SqlParameter("@pN_TipoDocumento", consultaReportesDocSinMovimiento.TipoDocumento);
            var fechaFinParameter = new SqlParameter("@pF_FechaFin", consultaReportesDocSinMovimiento.FechaFin);
            var fechaInicioParameter = new SqlParameter("@pF_FechaInicio", consultaReportesDocSinMovimiento.FechaInicio);

            var documentosSinMovimiento = await _context.reporteDocSinMovimientos
                .FromSqlRaw("EXEC GD.PA_ReportesDocSinMovimiento @pN_OficinaID,@pN_TipoDocumento, @pF_FechaFin,@pF_FechaInicio",
                                oficinaIDParameter,
                                tipoDocumentoParameter,
                                fechaFinParameter,
                                fechaInicioParameter)
                .ToListAsync();
            return documentosSinMovimiento.Select(c => new ReporteDocSinMovimiento
            {
                Acceso = c.Acceso,
                CodigoDocumento = c.CodigoDocumento,
                Fecha = c.Fecha,
                NombreDocumento = c.NombreDocumento,
                OficinaResponsable = c.OficinaResponsable,
                Version = c.Version
            }).ToList();
        }
    }
}
