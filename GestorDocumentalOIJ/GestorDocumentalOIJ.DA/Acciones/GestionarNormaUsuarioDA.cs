using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using GestorDocumentalOIJ.DA.Contexto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Acciones
{
    public class GestionarNormaUsuarioDA:IGestionarNormaUsuarioDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarNormaUsuarioDA(GestorDocumentalContext context)
        {
            _context = context;
        }


        public async Task<bool> AsignarNormaUsuario(NormaUsuario normaUsuario)
        {
            var normaIDParameter = new SqlParameter("@pN_NormaID", normaUsuario.NormaID);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", normaUsuario.UsuarioID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                              "EXEC GD.PA_InsertarNormaUsuario @pN_NormaID, @pN_UsuarioID",
                                                  normaIDParameter,
                                                  usuarioIDParameter);

            // Devuelve true si se afectó al menos una fila
            return resultado > 0;
        }

        public async Task<bool> EliminarNormaUsuario(NormaUsuario normaUsuario)
        {
            var normaIDParameter = new SqlParameter("@pN_NormaID", normaUsuario.NormaID);
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", normaUsuario.UsuarioID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC GD.PA_EliminarNormaUsuario @pN_NormaID, @pN_UsuarioID",
                                                               normaIDParameter,
                                                               usuarioIDParameter);

            // Devuelve true si se afectó al menos una fila
            return resultado > 0;
        }
    }
}
