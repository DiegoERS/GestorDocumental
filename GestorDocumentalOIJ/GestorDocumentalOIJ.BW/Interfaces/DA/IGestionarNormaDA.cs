using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.DA
{
    public interface IGestionarNormaDA
    {
        Task<IEnumerable<Norma>> ListarNormas();
        Task<Norma> ObtenerNorma(int id);
        Task<bool> CrearNorma(Norma norma);
        Task<bool> ActualizarNorma(Norma norma);
        Task<bool> EliminarNorma(EliminarRequest eliminarRequest);
    }
}
