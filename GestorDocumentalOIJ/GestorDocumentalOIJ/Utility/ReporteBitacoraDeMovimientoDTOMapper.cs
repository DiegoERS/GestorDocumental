using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DA.Entidades;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.Utility
{
    public class ReporteBitacoraDeMovimientoDTOMapper
    {
        public static ReporteBitacoraDeMovimientoDTO ConvertirReporteBitacoraDeMovimientoADTO(ReporteBitacoraDeMovimiento reporteBitacoraDeMovimiento)
        {
            return new ReporteBitacoraDeMovimientoDTO()
            {
                Acceso = reporteBitacoraDeMovimiento.Acceso,
                CodigoDocumento = reporteBitacoraDeMovimiento.CodigoDocumento,
                Fecha = reporteBitacoraDeMovimiento.Fecha,
                Movimiento = reporteBitacoraDeMovimiento.Movimiento,
                NombreDocumento = reporteBitacoraDeMovimiento.NombreDocumento,
                OficinaResponsable = reporteBitacoraDeMovimiento.OficinaResponsable,
                Usuario = reporteBitacoraDeMovimiento.Usuario,
                Version = reporteBitacoraDeMovimiento.Version
            };
        }

        public static ReporteBitacoraDeMovimiento ConvertirDTOAReporteBitacoraDeMovimiento(ReporteBitacoraDeMovimientoDTO reporteBitacoraDeMovimientoDTO)
        {
            return new ReporteBitacoraDeMovimiento()
            {
                Version = reporteBitacoraDeMovimientoDTO.Version,
                Usuario = reporteBitacoraDeMovimientoDTO.Usuario,
                OficinaResponsable = reporteBitacoraDeMovimientoDTO .OficinaResponsable,
                NombreDocumento = reporteBitacoraDeMovimientoDTO.NombreDocumento,  
                Movimiento = reporteBitacoraDeMovimientoDTO.Movimiento,
                Fecha = reporteBitacoraDeMovimientoDTO.Fecha,       
                Acceso = reporteBitacoraDeMovimientoDTO.Acceso,
                CodigoDocumento = reporteBitacoraDeMovimientoDTO.CodigoDocumento
            };
        }

        public static IEnumerable<ReporteBitacoraDeMovimientoDTO> ConvertirListaDeReporteBitacoraDeMovimientoADTO(IEnumerable<ReporteBitacoraDeMovimiento> reporteBitacoraDeMovimientos)
        {
            return reporteBitacoraDeMovimientos.Select(c => new ReporteBitacoraDeMovimientoDTO()
            {
                Acceso = c.Acceso,
                CodigoDocumento = c.CodigoDocumento,
                Fecha= c.Fecha,
                Movimiento= c.Movimiento,
                NombreDocumento = c.NombreDocumento,
                OficinaResponsable = c.OficinaResponsable,
                Usuario = c.Usuario,
                Version = c.Version
            });
        }
    }
}
