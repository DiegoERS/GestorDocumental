using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.BW.Interfaces.BW;
using GestorDocumentalOIJ.BW.Interfaces.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.BW.CU
{
    public class GestionarEtapaBW:IGestionarEtapaBW
    {
        private readonly IGestionarEtapaDA gestionarEtapaDA;
        public GestionarEtapaBW(IGestionarEtapaDA gestionarEtapaDA)
        {
            this.gestionarEtapaDA = gestionarEtapaDA;
        }

        public async Task<bool> ActualizarEtapa(Etapa etapa)
        {
            return await gestionarEtapaDA.ActualizarEtapa(etapa);
        }

        public async Task<bool> CrearEtapa(Etapa etapa)
        {
            return await gestionarEtapaDA.CrearEtapa(etapa);
        }

        public async Task<bool> EliminarEtapa(int id)
        {
            return await gestionarEtapaDA.EliminarEtapa(id);
        }

        public async Task<Etapa> ObtenerEtapaPorId(int idEtapa)
        {
            return await gestionarEtapaDA.ObtenerEtapaPorId(idEtapa);
        }

        public async Task<IEnumerable<Etapa>> ObtenerEtapas()
        {
            return await gestionarEtapaDA.ObtenerEtapas();
        }
    }
}
