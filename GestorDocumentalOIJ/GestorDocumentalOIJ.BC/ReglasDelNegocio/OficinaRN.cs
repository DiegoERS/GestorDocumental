using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class OficinaRN
    {
        public static (bool esValido, string mensaje) LaOficinaEsValida(Oficina oficina)
        {
            if (string.IsNullOrWhiteSpace(oficina.Nombre))
                return (false, "El nombre de la oficina es requerido");

            if (string.IsNullOrWhiteSpace(oficina.CodigoOficina))
                return (false, "La dirección de la oficina es requerida");

            if (oficina.Id < 0)
                return (false, "El id de la oficina es requerido");


            return (true, string.Empty);
        }
    }
}
