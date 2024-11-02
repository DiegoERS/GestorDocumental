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
    public class GestionarOficinaGestorDA:IGestionarOficinaGestorDA
    {
        private readonly GestorDocumentalContext _context;

        public GestionarOficinaGestorDA(GestorDocumentalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OficinaGestor>> obtenerOficinasGestores()
        {
            var permisosRol = await _context.OficinasGestores
                .FromSqlRaw("EXEC SC.PA_ListarGestorOficina")
                .ToListAsync();
            return permisosRol.Select(og => new OficinaGestor
            {
                GestorID = og.GestorID,
                OficinaID = og.OficinaID
            }).ToList();
        }

        public async Task<bool> AsignarOficinaAGestor(OficinaGestor oficinaGestor)
        {
            var gestorParameter = new SqlParameter("@pN_GestorID", oficinaGestor.GestorID);
            var oficinaParameter = new SqlParameter("@pN_OficinaID", oficinaGestor.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync("EXEC SC.PA_InsertarOficinaGestor @pN_GestorID, @pN_OficinaID", gestorParameter, oficinaParameter);

            return resultado > 0;
        }

        public async Task<bool> RemoverOficinaAGestor(OficinaGestor oficinaGestor)
        {
            var gestorParameter = new SqlParameter("@pN_GestorID", oficinaGestor.GestorID);
            var oficinaParameter = new SqlParameter("@pN_OficinaID", oficinaGestor.OficinaID);

            int resultado = await _context.Database.ExecuteSqlRawAsync("EXEC SC.PA_EliminarOficinaGestor @pN_GestorID, @pN_OficinaID", gestorParameter, oficinaParameter);

            return resultado > 0;
        }
    }
}
