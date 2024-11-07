namespace GestorDocumentalOIJ.DTOs
{
    public class ConsultaReporteDocSinMovimientoDTO
    {
        public int OficinaID { get; set; }
        public string TipoDocumento { get; set; } = string.Empty;
        public string FechaInicio { get; set; } = string.Empty;
        public string FechaFin {  get; set; } = string.Empty;
    }
}
