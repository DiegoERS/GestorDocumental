using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public class ConsultaReporteDocSinMovimientoDTOMapper
    {
        public static ConsultaReportesDocSinMovimientoDTO ConvertirConsultaReportesDocSinMovimientoADTO(ConsultaReportesDocSinMovimiento consultaReportesDocSin)
        {
            return new ConsultaReportesDocSinMovimientoDTO()
            {
                FechaFin = consultaReportesDocSin.FechaFin,
                FechaInicio = consultaReportesDocSin.FechaInicio,
                OficinaID = consultaReportesDocSin.OficinaID,
                TipoDocumento = consultaReportesDocSin.TipoDocumento
            };
        }

        public static ConsultaReportesDocSinMovimiento ConvertirDTOAConsultaReportesDocSinMovimiento(ConsultaReportesDocSinMovimientoDTO consultaReportesDocSinMovimientoDTO)
        {
            return new ConsultaReportesDocSinMovimiento()
            {
                TipoDocumento = consultaReportesDocSinMovimientoDTO.TipoDocumento,
                OficinaID = consultaReportesDocSinMovimientoDTO.OficinaID, 
                FechaInicio = consultaReportesDocSinMovimientoDTO.FechaInicio,
                FechaFin = consultaReportesDocSinMovimientoDTO.FechaFin
            };
        }
    }
}
