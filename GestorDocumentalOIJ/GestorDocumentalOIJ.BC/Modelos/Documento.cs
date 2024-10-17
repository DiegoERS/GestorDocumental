using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.Modelos
{
    public class Documento
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Asunto { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string PalabraClave { get; set; } = string.Empty;
        public int CategoriaID { get; set; }
        public int TipoDocumento { get; set; }
        public int OficinaID { get; set; }
        public string Vigencia { get; set; } = string.Empty;
        public int EtapaID { get; set; }
        public int SubClasificacionID { get; set; }
        public IEnumerable<RelacionesDoc> doctos { get; set; }= new List<RelacionesDoc>();

        public bool activo { get; set; }

        public bool descargable { get; set; }

        public int doctoId { get; set; }
        public int ClasificacionID { get; set; }
        public int NormaID { get; set; }
    }
}
