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
    public static class ConsultaReporteControlDeVersionesDTOMapper
    {
        public static ConsultaReporteControlDeVersionesDTO ConvertirConsultaReporteControlDeVersionesoADTO(ConsultaReporteControlDeVersiones consultaReporteControlDeVersiones)
        {
            return new ConsultaReporteControlDeVersionesDTO()
            {
                CodigoDocumento = consultaReporteControlDeVersiones.CodigoDocumento,
                NombreDocumento = consultaReporteControlDeVersiones.NombreDocumento,
                TipoDocumento = consultaReporteControlDeVersiones.TipoDocumento
            };
        }

        public static ConsultaReporteControlDeVersiones ConvertirDTOAConsultaReporteControlDeVersiones(ConsultaReporteControlDeVersionesDTO consultaReporteControlDeVersionesDTO)
        {
            return new ConsultaReporteControlDeVersiones()
            {
                CodigoDocumento = consultaReporteControlDeVersionesDTO.CodigoDocumento,
                TipoDocumento = consultaReporteControlDeVersionesDTO.TipoDocumento,
                NombreDocumento = consultaReporteControlDeVersionesDTO.NombreDocumento
            };
        }
    }
}
