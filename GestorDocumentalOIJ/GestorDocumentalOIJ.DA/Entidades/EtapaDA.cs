﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Entidades
{
    public class EtapaDA
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool eliminado { get; set; }
        public string color { get; set; } = string.Empty;
        public int EtapaPadreID { get; set; }
        public int normaID { get; set; }

        public int Consecutivo { get; set; }

    }
}
