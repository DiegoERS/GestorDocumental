namespace GestorDocumentalOIJ.DTOs
{
    public class ConsultaReporteBitacoraDeMovimiento
    {
        public int OficinaID { get; set; }
        public int UsuarioID { get; set; }
        public string NombreDocumento { get; set; } = string.Empty;
        public string CodigoDocumento { get; set; } = string.Empty;
        public string FechaInicio { get; set; } = string.Empty;
        public string FechaFin { get; set; } = string.Empty;
    }
}
