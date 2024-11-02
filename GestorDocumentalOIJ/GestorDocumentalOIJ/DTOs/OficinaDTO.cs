namespace GestorDocumentalOIJ.DTOs
{
    public class OficinaDTO
    {

        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CodigoOficina { get; set; } = string.Empty;
        public bool Gestor { get; set; }
        public bool Eliminado { get; set; }
    }
}
