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
    public class GestionarUsuarioOficinaDA : IGestionarUsuarioOficinaDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarUsuarioOficinaDA(GestorDocumentalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioOficina>> ObtenerUsuariosOficinas()
        {
            var usuariosOficinas = await _context.UsuariosOficinas
                .FromSqlRaw("EXEC SC.PA_ListarOficinaUsuario")
                .ToListAsync();

            return usuariosOficinas.Select(uo => new UsuarioOficina
            {
                UsuarioID = uo.UsuarioID,
                OficinaID = uo.OficinaID
            }).ToList();
        }

        public async Task<bool> AsignarUsuarioAOficina(UsuarioOficina usuarioOficina)
        {
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", usuarioOficina.UsuarioID);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", usuarioOficina.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                             "EXEC SC.PA_InsertarOficinaUsuario @pN_OficinaID, @pN_UsuarioID",
                                                                  oficinaIDParameter,
                                                                  usuarioIDParameter);

            return resultado > 0;
        }

        public async Task<bool> RemoverUsuarioAOficina(UsuarioOficina usuarioOficina)
        {
            var usuarioIDParameter = new SqlParameter("@pN_UsuarioID", usuarioOficina.UsuarioID);
            var oficinaIDParameter = new SqlParameter("@pN_OficinaID", usuarioOficina.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync(
                                                                  "EXEC SC.PA_EliminarOficinaUsuario @pN_OficinaID, @pN_UsuarioID",
                                                                        oficinaIDParameter,
                                                                        usuarioIDParameter);

            return resultado > 0;
        }
    }
}
