using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DA.Entidades;

namespace GestorDocumentalOIJ.Utility
{
    public static class ConsultaReporteDescargaDeDocumentosDTOMapper
    {
        public static ConsultaReporteDescargaDeDocumentosDTO ConvertirConsultaReporteDescargaDeDocumentosADTO(ConsultaReporteDescargaDeDocumentos consultaReporteDescargaDeDocumentos)
        {
            return new ConsultaReporteDescargaDeDocumentosDTO()
            {
                CodigoDocumento = consultaReporteDescargaDeDocumentos.CodigoDocumento,
                NombreDocumento = consultaReporteDescargaDeDocumentos.NombreDocumento,
                Usuario = consultaReporteDescargaDeDocumentos.Usuario,
                Oficina = consultaReporteDescargaDeDocumentos.Oficina,
                FechaInicio = consultaReporteDescargaDeDocumentos.FechaInicio,
                FechaFinal = consultaReporteDescargaDeDocumentos.FechaFinal
            };
        }

        public static ConsultaReporteDescargaDeDocumentos ConvertirDTOAConsultaReporteDescargaDeDocumentos(ConsultaReporteDescargaDeDocumentosDTO consultaReporteDescargaDeDocumentosDTO)
        {
            return new ConsultaReporteDescargaDeDocumentos()
            {
                NombreDocumento = consultaReporteDescargaDeDocumentosDTO.NombreDocumento,
                CodigoDocumento = consultaReporteDescargaDeDocumentosDTO.CodigoDocumento,
                FechaFinal = consultaReporteDescargaDeDocumentosDTO.FechaFinal,
                FechaInicio =  consultaReporteDescargaDeDocumentosDTO.FechaInicio,
                Oficina = consultaReporteDescargaDeDocumentosDTO.Oficina,
                Usuario = consultaReporteDescargaDeDocumentosDTO.Usuario
            };
        }
    }
}
