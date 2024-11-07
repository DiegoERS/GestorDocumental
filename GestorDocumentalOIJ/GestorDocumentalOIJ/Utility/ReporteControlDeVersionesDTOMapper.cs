using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.DA.Entidades;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public static class ReporteControlDeVersionesDTOMapper
    {
        public static ReporteControlDeVersionesDTO ConvertirReporteControlDeVersionesADTO(ReporteControlDeVersiones reporteControlDeVersiones)
        {
            return new ReporteControlDeVersionesDTO()
            {
                CodigoDocumento = reporteControlDeVersiones.CodigoDocumento,
                Fecha = reporteControlDeVersiones.Fecha,
                NombreDocumento = reporteControlDeVersiones.NombreDocumento,
                ResumenDelCambio = reporteControlDeVersiones.ResumenDelCambio,
                SCD = reporteControlDeVersiones.SCD,
                TipoDocumento = reporteControlDeVersiones.TipoDocumento,
                Version = reporteControlDeVersiones.Version
            };
        }

        public static ReporteControlDeVersiones ConvertirDTOAReporteControlDeVersiones(ReporteControlDeVersionesDTO reporteControlDeVersionesDTO)
        {
            return new ReporteControlDeVersiones()
            {
                Version = reporteControlDeVersionesDTO.Version,
                TipoDocumento = reporteControlDeVersionesDTO.TipoDocumento, 
                SCD = reporteControlDeVersionesDTO.SCD,
                ResumenDelCambio = reporteControlDeVersionesDTO.ResumenDelCambio,
                NombreDocumento = reporteControlDeVersionesDTO.NombreDocumento,
                Fecha = reporteControlDeVersionesDTO.Fecha,
                CodigoDocumento = reporteControlDeVersionesDTO.CodigoDocumento
            };
        }

        public static IEnumerable<ReporteControlDeVersionesDTO> ConvertirListaDeReporteBitacoraDeMovimientoADTO(IEnumerable<ReporteControlDeVersiones> reporteControlDeVersiones)
        {
            return reporteControlDeVersiones.Select(c => new ReporteControlDeVersionesDTO()
            {
                CodigoDocumento = c.CodigoDocumento,
                Fecha = c.Fecha,
                NombreDocumento= c.NombreDocumento,
                ResumenDelCambio= c.ResumenDelCambio,
                SCD= c.ResumenDelCambio,
                TipoDocumento = c.TipoDocumento,
                Version = c.Version
            });
        }
    }
}
