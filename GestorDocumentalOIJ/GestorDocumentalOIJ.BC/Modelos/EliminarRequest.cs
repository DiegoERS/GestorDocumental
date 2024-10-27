using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BC.Modelos
{
    public class EliminarRequest
    {
        public int ObjetoID { get; set; }
        public int UsuarioID { get; set; }
        public int OficinaID { get; set; }
    }
}
