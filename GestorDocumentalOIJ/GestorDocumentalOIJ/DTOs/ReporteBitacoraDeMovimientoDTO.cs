namespace GestorDocumentalOIJ.DTOs
{
    public class ReporteBitacoraDeMovimientoDTO
    {
        public string CodigoDocumento {  get; set; } = string.Empty;
        public string NombreDocumento { get; set; } = string.Empty ;
        public string Acceso {  get; set; } = string.Empty ;
        public int Version { get; set; }
        public string FechaIngreso {  get; set; } = string.Empty ;
        public string Usuario {  get; set; } = string.Empty ;
        public string Movimiento { get; set; } = string.Empty;
        public string OficinaResponsable { get; set; } = string.Empty;
    }
}
