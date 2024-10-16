using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.Modelos
{
    public class DocumentoExtendido: Documento
    {
        public int NormaID { get; set; }
        public int VersionID { get; set; }
        public int ClasificacionID { get; set; }
    }
}
