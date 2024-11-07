using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.DTOs;

namespace GestorDocumentalOIJ.DA.Entidades
{
    public class ConsultaReporteBitacoraDeMovimientoDTOMapper
    {
        public static ConsultaReporteBitacoraDeMovimientoDTO ConvertirConsultaReporteBitacoraDeMovimientoADTO(ConsultaReporteBitacoraDeMovimiento consultaReporteBitacoraDeMovimiento)
        {
            return new ConsultaReporteBitacoraDeMovimientoDTO()
            {
                CodigoDocumento = consultaReporteBitacoraDeMovimiento.CodigoDocumento,
                FechaFin = consultaReporteBitacoraDeMovimiento.FechaFin,
                FechaInicio = consultaReporteBitacoraDeMovimiento.FechaInicio,
                NombreDocumento = consultaReporteBitacoraDeMovimiento.NombreDocumento,
                OficinaID = consultaReporteBitacoraDeMovimiento.OficinaID,
                UsuarioID = consultaReporteBitacoraDeMovimiento.UsuarioID
            };
        }

        public static ConsultaReporteBitacoraDeMovimiento ConvertirDTOAConsultaReporteBitacoraDeMovimiento(ConsultaReporteBitacoraDeMovimientoDTO consultaReporteBitacoraDeMovimientoDTO)
        {
            return new ConsultaReporteBitacoraDeMovimiento()
            {
                UsuarioID = consultaReporteBitacoraDeMovimientoDTO.UsuarioID,
                OficinaID = consultaReporteBitacoraDeMovimientoDTO.OficinaID,
                NombreDocumento = consultaReporteBitacoraDeMovimientoDTO .NombreDocumento,
                FechaInicio = consultaReporteBitacoraDeMovimientoDTO.FechaInicio,
                FechaFin = consultaReporteBitacoraDeMovimientoDTO.FechaFin,
                CodigoDocumento = consultaReporteBitacoraDeMovimientoDTO.CodigoDocumento
            };
        }

    }
}
