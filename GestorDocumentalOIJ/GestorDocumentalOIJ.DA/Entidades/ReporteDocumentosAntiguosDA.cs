﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Entidades
{
    public class ReporteDocumentosAntiguosDA
    {
        public string CodigoDocumento { get; set; } = string.Empty;
        public string NombreDocumento { get; set; } = string.Empty;
        public string Acceso { get; set; } = string.Empty;
        public int Version { get; set; }
        public DateTime Fecha { get; set; } 
        public string OficinaResponsable { get; set; } = string.Empty;
    }
}
