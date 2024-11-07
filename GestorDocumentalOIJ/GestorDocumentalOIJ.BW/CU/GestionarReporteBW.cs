using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.BW.Interfaces.DA;

namespace GestorDocumentalOIJ.BW.CU
{
    public class GestionarReporteBW : IGestionarReporteBW
    {
        private readonly IGestionarReporteDA _gestionarReporteDA;

        public GestionarReporteBW(IGestionarReporteDA gestionarReporteDA)
        {
            _gestionarReporteDA = gestionarReporteDA;
        }

        public async Task<IEnumerable<ReporteDocSinMovimiento>> ObtenerReportesDocSinMovimiento(ConsultaReportesDocSinMovimiento consultaReportesDocSinMovimiento)
        {
            return await _gestionarReporteDA.ObtenerReportesDocSinMovimiento(consultaReportesDocSinMovimiento);
        }
    }
}
