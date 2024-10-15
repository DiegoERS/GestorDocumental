namespace GestorDocumentalOIJ.DTOs
{
    public class DocumentoDTO
    {
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
        public string Doctos { get; set; } = string.Empty;
    }
}
