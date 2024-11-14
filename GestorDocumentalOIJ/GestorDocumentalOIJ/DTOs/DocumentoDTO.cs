using GestorDocumentalOIJ.BC.Modelos;

namespace GestorDocumentalOIJ.DTOs
{
    public class DocumentoDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Asunto { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public IEnumerable<string> PalabraClave { get; set; } = new List<string>();
        public int CategoriaID { get; set; }
        public int TipoDocumento { get; set; }
        public int OficinaID { get; set; }
        public string Vigencia { get; set; } = string.Empty;
        public int EtapaID { get; set; }
        public int SubClasificacionID { get; set; }
        public IEnumerable<RelacionesDoc> doctos { get; set; } = new List<RelacionesDoc>();

        public bool activo { get; set; }

        public bool descargable { get; set; }

        public int doctoId { get; set; }
        public int ClasificacionID { get; set; }
        public int NormaID { get; set; }

        public int VersionID { get; set; }

        public int UsuarioID { get; set; }
        public int OficinaUsuarioID { get; set; }

        public int numeroVersion { get; set; }
    }
}
