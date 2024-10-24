namespace GestorDocumentalOIJ.DTOs
{
    public class DocumentoExtendidoDTO : DocumentoDTO
    {
       public IFormFile Archivo { get; set; }

        public string urlArchivo { get; set; } = string.Empty;
    }
}
