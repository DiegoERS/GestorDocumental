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

        public Task<IEnumerable<ReporteControlDeVersiones>> ObtenerReporteControlDeVersiones(ConsultaReporteControlDeVersiones consultaReporteControlDeVersiones)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReporteDescargaDeDocumentos>> ObtenerReporteDescargaDeDocumentos(ConsultaReporteDescargaDeDocumentos consultaReporteDescargaDeDocumentos)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReporteDocumentosAntiguos>> ObtenerReporteDocumentosAntiguos(ConsultaReporteDocumentosAntiguos consultaReporteDocumentosAntiguos)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReporteMaestroDocumentoPorNorma>> ObtenerReporteMaestroDocumentoPorNorma(ConsultaReporteMaestroDocumentoPorNorma consultaReporteMaestroDocumentoPorNorma)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReporteMaestroDocumentos>> ObtenerReporteMaestroDocumentos(ConsultaReporteMaestroDocumentos consultaReporteMaestroDocumentos)
        {
            throw new NotImplementedException();
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
