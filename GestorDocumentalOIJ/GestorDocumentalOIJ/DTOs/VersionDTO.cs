namespace GestorDocumentalOIJ.DTOs
{
    public class VersionDTO
    {
        public int Id { get; set; }
        public int DocumentoID { get; set; }

        public int NumeroVersion { get; set; }

        public string FechaCreacion { get; set; } = string.Empty;

        public IFormFile archivo { get; set; } = null;

        public bool eliminado { get; set; }

        public int usuarioID { get; set; }

        public bool DocDinamico { get; set; }

        public bool Obsoleto { get; set; }

        public string NumeroSCD { get; set; } = string.Empty;

        public string justificacion { get; set; } = string.Empty;
        public int UsuarioLogID { get; set; }
        public int OficinaID { get; set; }
    }
}
