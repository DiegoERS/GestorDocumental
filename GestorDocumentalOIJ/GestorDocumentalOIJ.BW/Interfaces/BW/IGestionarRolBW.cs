using GestorDocumentalOIJ.BC.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.Interfaces.BW
{
    public interface IGestionarRolBW
    {
        Task<IEnumerable<Rol>> ObtenerRoles();
        Task<Rol> ObtenerRolPorId(int id);

        Task<bool> CrearRol(Rol rol);

        Task<bool> ActualizarRol(Rol rol);

        Task<bool> EliminarRol(int id);


    }
}
