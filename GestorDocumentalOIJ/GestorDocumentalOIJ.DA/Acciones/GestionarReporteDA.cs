using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Contexto;
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

        public async Task<IEnumerable<ReporteDocSinMovimiento>> ObtenerReportesDocSinMovimiento(ConsultaReportesDocSinMovimiento consultaReportesDocSinMovimiento)
        {
            var documentosSinMovimiento = await _context.reporteDocSinMovimientos
                .FromSqlRaw("EXEC GD.PA_ReportesDocSinMovimiento")
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
