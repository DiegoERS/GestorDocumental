namespace GestorDocumentalOIJ.Utility
{
    public static class SaveFiles
    {
        public static async Task<bool> SaveFile(IFormFile file)
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
