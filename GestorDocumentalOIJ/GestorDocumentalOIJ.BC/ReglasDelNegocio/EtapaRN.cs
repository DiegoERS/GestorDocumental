using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.ReglasDelNegocio
{
    public static class EtapaRN
    {
        public static (bool esValido, string mensaje) LaEtapaEsValida(Etapa etapa)
        {
            if (string.IsNullOrWhiteSpace(etapa.Nombre))
                return (false, "El nombre de la etapa es requerido");

            if (string.IsNullOrWhiteSpace(etapa.Descripcion))
                return (false, "La descripción de la etapa es requerida");

            if (etapa.UsuarioID < 0)
                return (false, "El usuario es requerido");

            if (etapa.OficinaID < 0)
                return (false, "La oficina es requerida");

            if (etapa.normaID < 0)
                return (false, "La norma es requerida");

            if (etapa.EtapaPadreID < 0)
                return (false, "La etapa padre es requerida");

            if (string.IsNullOrWhiteSpace(etapa.color))
                return (false, "El color es requerido");


            return (true, string.Empty);
        }
    }

}
