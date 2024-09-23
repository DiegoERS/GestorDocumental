namespace GestorDocumentalOIJ.DTOs
{
    public class EtapaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Eliminado { get; set; }

        public int normaID { get; set; }
    }
}
