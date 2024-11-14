namespace GestorDocumentalOIJ.DTOs
{
    public class EtapaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Eliminado { get; set; }
        public string color { get; set; } = string.Empty;
        public int EtapaPadreID { get; set; }
        public int normaID { get; set; }
        public int Consecutivo { get; set; }
        public int UsuarioID { get; set; }
        public int OficinaID { get; set; }
    }
}
