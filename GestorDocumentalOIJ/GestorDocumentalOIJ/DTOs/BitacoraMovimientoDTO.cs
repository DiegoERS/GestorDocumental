namespace GestorDocumentalOIJ.DTOs
{
    public class BitacoraMovimientoDTO
    {
        public int IdMovimiento { get; set; }
        public int VersionID { get; set; }
        public string FechaIngreso { get; set; } = string.Empty;
        public int UsuarioID { get; set; }
        public bool Movimiento { get; set; }
    }
}
