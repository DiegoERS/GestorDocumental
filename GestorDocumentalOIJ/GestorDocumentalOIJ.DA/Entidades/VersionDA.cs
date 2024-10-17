using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Entidades
{
    public class VersionDA
    {
        public int Id { get; set; }
        public int DocumentoID { get; set; }

        public int NumeroVersion { get; set; }

        public string FechaCreacion { get; set; } = string.Empty;

        public string urlVersion { get; set; } = string.Empty;

        public bool eliminado { get; set; }

        public int usuarioID { get; set; }

        public bool DocDinamico { get; set; }

        public bool Obsoleto { get; set; }

        public string NumeroSCD { get; set; } = string.Empty;

        public string justificacion { get; set; } = string.Empty;
    }
}
