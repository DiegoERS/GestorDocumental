﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Entidades
{
    public class ConsultaReporteMaestroDocumentoPorNormaDTO
    {
        public int Oficina { get; set; }
        public int TipoDocumento { get; set; }
        public int Norma { get; set; }
        public int Categoria { get; set; }
    }
}