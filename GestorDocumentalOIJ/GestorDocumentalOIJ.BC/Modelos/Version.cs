using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.Modelos
{
    public class Version
    {
        public int Id { get; set; }
        public int DocumentoID { get; set; } 

        public int NumeroVersion { get; set; }

        public string FechaCreacion { get; set; }= string.Empty;

        public string urlVersion { get; set; } = string.Empty;

        public bool eliminado { get; set; }

        public int usuarioID { get; set; }
    }
}
