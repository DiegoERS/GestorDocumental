﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.Modelos
{
    public class PalabrasClaves
    {
        public IEnumerable<PalabraClave> PalabraClave { get; set; } = new List<PalabraClave>();
    }
}