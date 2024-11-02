using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class OficinaGestorRN
    {
        public static (bool esValido, string mensaje) LaOficinaGestorEsValida(OficinaGestor oficinaGestor)
        {
            if (oficinaGestor.OficinaID<0)
                return (false, "La oficina es requerida");

            if (oficinaGestor.GestorID < 0)
                return (false, "El gestor es requerido");

            return (true, string.Empty);


        }

    }
}
