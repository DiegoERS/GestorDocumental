﻿namespace GestorDocumentalOIJ.DTOs
{
    public class TipoDocumentoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Eliminado { get; set; }
    }
}