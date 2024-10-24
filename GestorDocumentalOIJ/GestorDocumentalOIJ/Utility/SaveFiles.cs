namespace GestorDocumentalOIJ.Utility
{
    public static class SaveFiles
    {
        public static async Task<string> SaveFile(IFormFile file)
        {
            // Definir la ruta hacia la carpeta "Archivos"
            var nombreArchivo = Path.GetFileName(file.FileName);
            var rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "GestorDocumentalOIJ", "Archivos");
            var rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

            try
            {
                if (!Directory.Exists(rutaCarpeta))
                {
                    Directory.CreateDirectory(rutaCarpeta);
                }

                using (var fileStream = new FileStream(rutaCompleta, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                // Guardar la ruta en la base de datos si es necesario...
                return rutaCompleta;
            }
            catch (Exception)
            {
                return "";
            }
        }


        public static  IFormFile GetIFormFile(string rutaArchivo)
        {
            try
            {
                // Verificar si el archivo existe
                if (System.IO.File.Exists(rutaArchivo))
                {
                    // Leer todo el archivo en un MemoryStream
                    var memoryStream = new MemoryStream();
                    using (var stream = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
                    {
                         stream.CopyToAsync(memoryStream);
                    }

                    // Reiniciar la posición del MemoryStream a 0 para leerlo desde el principio
                    memoryStream.Position = 0;

                    // Crear un FormFile desde el MemoryStream
                    var formFile = new FormFile(memoryStream, 0, memoryStream.Length, null, Path.GetFileName(rutaArchivo))
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = GetMimeType(rutaArchivo)
                    };

                    return formFile;
                }
                else
                {
                    return null; // Si el archivo no existe
                }
            }
            catch (Exception)
            {
                return null; // En caso de error
            }
        }

        // Método auxiliar para obtener el tipo MIME en función de la extensión del archivo
        private static string GetMimeType(string filePath)
        {
            var ext = Path.GetExtension(filePath).ToLowerInvariant();
            return ext switch
            {
                ".txt" => "text/plain",
                ".pdf" => "application/pdf",
                ".doc" => "application/vnd.ms-word",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".xls" => "application/vnd.ms-excel",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                ".png" => "image/png",
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".gif" => "image/gif",
                ".csv" => "text/csv",
                _ => "application/octet-stream", // Por defecto
            };
        }
    }
}
