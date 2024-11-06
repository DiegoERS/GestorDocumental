﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDocumentalOIJ.DA.Contexto
{
    public class GestorDocumentalContext : DbContext
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

        public DbSet<Entidades.DocumentoExtendidoDA> DocumentosExtendidos { get; set; }

        public DbSet<Entidades.DoctoDA> Doctos { get; set; }

        public DbSet<Entidades.OficinaDA> Oficinas { get; set; }

        public DbSet<Entidades.UsuarioDA> Usuarios { get; set; }

        public DbSet<Entidades.SubclasificacionDA> Subclasificaciones { get; set; }

        public DbSet<Entidades.VersionDA> Versiones { get; set; }

        public DbSet<Entidades.RolDA> Roles { get; set; }

        public DbSet<Entidades.PermisoDA> Permisos { get; set; }

        public DbSet<Entidades.PermisoRolDA> PermisosRoles { get; set; }

        public DbSet<Entidades.PermisoOficinaDA> PermisosOficinas { get; set; }

        public DbSet<Entidades.OficinaGestorDA> OficinasGestores { get; set; }

        public DbSet<Entidades.UsuarioOficinaDA> UsuariosOficinas { get; set; }

        public DbSet<Entidades.NormaUsuarioDA> NormasUsuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entidades.PermisoOficinaDA>().HasNoKey();
            modelBuilder.Entity<Entidades.PermisoRolDA>().HasNoKey();
            modelBuilder.Entity<Entidades.OficinaGestorDA>().HasNoKey();
            modelBuilder.Entity<Entidades.UsuarioOficinaDA>().HasNoKey();
            modelBuilder.Entity<Entidades.NormaUsuarioDA>().HasNoKey();
            modelBuilder.Entity<Entidades.UsuarioDA>().HasNoKey();

            // Si tienes otras configuraciones para otras entidades, colócalas aquí también
            base.OnModelCreating(modelBuilder);

        }


    }
}
