using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DA.Entidades;

namespace GestorDocumentalOIJ.Utility
{
    public static class ConsultaReporteMaestroDocumentosDTOMapper
    {
        public static ConsultaReporteMaestroDocumentosDTO ConvertirConsultaReporteMaestroDocumentosADTO(ConsultaReporteMaestroDocumentos consultaReporteMaestroDocumentos)
        {
            return new ConsultaReporteMaestroDocumentosDTO()
            {
                Oficina = consultaReporteMaestroDocumentos.Oficina,
                TipoDocumento = consultaReporteMaestroDocumentos.TipoDocumento
            };
        }

        public static ConsultaReporteMaestroDocumentos ConvertirDTOAConsultaReporteMaestroDocumentos(ConsultaReporteMaestroDocumentosDTO consultaReporteMaestroDocumentosDTO)
        {
            return new ConsultaReporteMaestroDocumentos()
            {
                Oficina = consultaReporteMaestroDocumentosDTO.Oficina,
                TipoDocumento = consultaReporteMaestroDocumentosDTO.TipoDocumento
            };
        }
    }
}
