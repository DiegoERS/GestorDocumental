using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public class ReporteDocSinMovimientoDTOMapper
    {
        public static ReportesDocSinMovimientoDTO ConvertirReportesDocSinMovimientoADTO(ReporteDocSinMovimiento reportesDocSinMovimiento)
        {
            return new ReportesDocSinMovimientoDTO()
            {
                Acceso = reportesDocSinMovimiento.Acceso,
                CodigoDocumento = reportesDocSinMovimiento.CodigoDocumento,
                Fecha = reportesDocSinMovimiento.Fecha,
                NombreDocumento = reportesDocSinMovimiento.NombreDocumento,
                OficinaResponsable = reportesDocSinMovimiento.OficinaResponsable,
                Version = reportesDocSinMovimiento.Version
            };
        }

        public static ReporteDocSinMovimiento ConvertirDTOAReportesDocSinMovimiento(ReportesDocSinMovimientoDTO reportesDocSinMovimientoDTO)
        {
            return new ReporteDocSinMovimiento()
            {
                Version = reportesDocSinMovimientoDTO.Version,
                OficinaResponsable = reportesDocSinMovimientoDTO.OficinaResponsable,
                Fecha = reportesDocSinMovimientoDTO .Fecha,
                CodigoDocumento = reportesDocSinMovimientoDTO.CodigoDocumento,  
                Acceso = reportesDocSinMovimientoDTO.Acceso,
                NombreDocumento = reportesDocSinMovimientoDTO.NombreDocumento
            };
        }

        public static IEnumerable<ReportesDocSinMovimientoDTO> ConvertirListaDeReportesDocSinMovimientosADTO(IEnumerable<ReporteDocSinMovimiento> reportesDocSinMovimientos)
        {
            return reportesDocSinMovimientos.Select(c => new ReportesDocSinMovimientoDTO()
            {
                NombreDocumento = c.NombreDocumento,
                Fecha = c.Fecha,
                Acceso = c.Acceso,
                CodigoDocumento= c.CodigoDocumento,
                OficinaResponsable = c.OficinaResponsable,
                Version = c.Version
            });
        }
    }
}
