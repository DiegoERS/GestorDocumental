using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DA.Entidades;

namespace GestorDocumentalOIJ.Utility
{
    public static class ConsultaReporteMaestroDocumentoPorNormaDTOMapper
    {
        public static ConsultaReporteMaestroDocumentoPorNormaDTO ConvertirConsultaReporteMaestroDocumentoPorNormaADTO(ConsultaReporteMaestroDocumentoPorNorma consultaReporteMaestroDocumentoPorNorma)
        {
            return new ConsultaReporteMaestroDocumentoPorNormaDTO()
            {
                TipoDocumento = consultaReporteMaestroDocumentoPorNorma.TipoDocumento,
                Oficina = consultaReporteMaestroDocumentoPorNorma.Oficina,
                Categoria = consultaReporteMaestroDocumentoPorNorma.Categoria,
                Norma = consultaReporteMaestroDocumentoPorNorma.Norma
            };
        }

        public static ConsultaReporteMaestroDocumentoPorNorma ConvertirDTOAConsultaReporteMaestroDocumentoPorNorma(ConsultaReporteMaestroDocumentoPorNormaDTO consultaReporteMaestroDocumentoPorNormaDTO)
        {
            return new ConsultaReporteMaestroDocumentoPorNorma()
            {
                TipoDocumento = consultaReporteMaestroDocumentoPorNormaDTO.TipoDocumento,
                Norma = consultaReporteMaestroDocumentoPorNormaDTO.Norma,
                Categoria = consultaReporteMaestroDocumentoPorNormaDTO.Categoria,
                Oficina = consultaReporteMaestroDocumentoPorNormaDTO.Oficina
            };
        }
    }
}
