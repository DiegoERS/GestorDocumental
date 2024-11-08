using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Contexto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestorDocumentalOIJ.DA.Acciones
{
    public class GestionarBitacoraMovimientoDA : IGestionarBitacoraMovimientoDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarBitacoraMovimientoDA(GestorDocumentalContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertarBitacoraMovimiento(BitacoraMovimiento bitacoraMovimiento)
        {

            var versionParameter = new SqlParameter("@pN_VersionID", bitacoraMovimiento.VersionID);
            var usuarioParameter = new SqlParameter("@pN_UsuarioID", bitacoraMovimiento.UsuarioID);
            var movimientoParameter = new SqlParameter("@pC_Movimiento", bitacoraMovimiento.Movimiento);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC  GD.PA_InsertarBitacoraMovimientos @pN_VersionID, @pN_UsuarioID, @pC_Movimiento",
                                                             versionParameter,
                                                             usuarioParameter,
                                                             movimientoParameter);
            return resultado > 0;
        }
    }
}
