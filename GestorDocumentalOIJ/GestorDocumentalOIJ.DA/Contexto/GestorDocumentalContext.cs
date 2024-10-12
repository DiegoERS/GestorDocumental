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

        public DbSet<Entidades.ClasificacionDA> Clasificaciones { get; set; }

        public DbSet<Entidades.DocumentoDA> Documentos { get; set; }
        
        public DbSet<Entidades.DoctoDA> Doctos { get; set; }

        public DbSet<Entidades.OficinaDA> Oficinas { get; set;}

        public DbSet<Entidades.UsuarioDA> Usuarios { get; set; }

        public DbSet<Entidades.SubclasificacionDA > Subclasificaciones { get; set; }

        public DbSet<Entidades.VersionDA> Versiones { get; set; }



    }
}
