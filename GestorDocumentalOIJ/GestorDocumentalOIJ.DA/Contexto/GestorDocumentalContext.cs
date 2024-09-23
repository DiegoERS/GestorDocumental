using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Contexto
{
    public class GestorDocumentalContext:DbContext
    {
        public GestorDocumentalContext(DbContextOptions<GestorDocumentalContext> options) : base(options)
        {
        }
        public DbSet<Entidades.CategoriaDA> Categorias { get; set; }
        public DbSet<Entidades.TipoDocumentoDA> TiposDocumentos { get; set; }
        public DbSet<Entidades.NormaDA> Normas { get; set; }
        public DbSet<Entidades.EtapaDA> Etapas { get; set; }
    }
}
