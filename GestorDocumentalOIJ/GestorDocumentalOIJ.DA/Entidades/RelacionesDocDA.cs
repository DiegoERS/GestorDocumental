using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Entidades
{
    public class RelacionesDocDA
    {
        public int Id { get; set; }
        public int docto { get; set; }
        public string docRelacionado { get; set; } = string.Empty;

    }
}
