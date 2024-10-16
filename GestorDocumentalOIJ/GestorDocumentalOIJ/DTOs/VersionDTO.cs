﻿namespace GestorDocumentalOIJ.DTOs
{
    public class VersionDTO
    {
        public int Id { get; set; }
        public int DocumentoID { get; set; }

        public int NumeroVersion { get; set; }

        public string FechaCreacion { get; set; } = string.Empty;

        public string urlVersion { get; set; } = string.Empty;

        public bool eliminado { get; set; }

        public int usuarioID { get; set; }
    }
}
