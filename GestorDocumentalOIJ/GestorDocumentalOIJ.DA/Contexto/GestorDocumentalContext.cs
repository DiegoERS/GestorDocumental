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
    }
}
