namespace GestorDocumentalOIJ.DTOs
{
    public class ReporteMaestroDocumentosDTO
    {
        public string CodigoDocumento { get; set; } = string.Empty;
        public string NombreDocumento { get; set; } = string.Empty;
        public string Estado {  get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;
        public string SCD { get; set; } = string.Empty;
        public int Version { get; set; }
        public string Fecha { get; set; } = string.Empty;
        public string ResumenDelCambio { get; set; } = string.Empty;
    }
}
