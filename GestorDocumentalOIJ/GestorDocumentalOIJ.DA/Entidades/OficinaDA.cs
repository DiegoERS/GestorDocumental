using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Entidades
{
    public class OficinaDA
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CodigoOficina { get; set; } = string.Empty;
        public bool Gestor { get; set; }
        public bool Eliminado { get; set; }
    }
}
