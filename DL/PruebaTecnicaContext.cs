using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DL
{
    public partial class PruebaTecnicaContext : DbContext
    {
        public PruebaTecnicaContext()
        {
        }

        public PruebaTecnicaContext(DbContextOptions<PruebaTecnicaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulo { get; set; }
        public virtual DbSet<ArticuloTienda> ArticuloTienda { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ClienteArticulo> ClienteArticulo { get; set; }
        public virtual DbSet<Colonia> Colonia { get; set; }
        public virtual DbSet<DireccionCliente> DireccionCliente { get; set; }
        public virtual DbSet<DireccionTienda> DireccionTienda { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<Tienda> Tienda { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<ClienteGetAllDTO> ClienteGetAllDTO { get; set; }
        public virtual DbSet<TiendaGetAllDTO> TiendaGetAllDTO { get; set; }
        public virtual DbSet<ClienteArticuloGetAllDTO> ClienteArticuloGetAllDTO { get; set; }



        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=.; Database=PruebaTecnica; TrustServerCertificate=True; User ID=SA; Password=pass@word1;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteArticuloGetAllDTO>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<TiendaGetAllDTO>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<ClienteGetAllDTO>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.IdArticulo)
                    .HasName("PK__Articulo__F8FF5D522394B7E2");

                entity.Property(e => e.Código)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("money");
            });

            modelBuilder.Entity<ArticuloTienda>(entity =>
            {
                entity.HasKey(e => e.IdArticuloTienda)
                    .HasName("PK__Articulo__32EA306A3086AB0C");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.ArticuloTienda)
                    .HasForeignKey(d => d.IdArticulo)
                    .HasConstraintName("FK__ArticuloT__IdArt__31EC6D26");

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.ArticuloTienda)
                    .HasForeignKey(d => d.IdTienda)
                    .HasConstraintName("FK__ArticuloT__IdTie__32E0915F");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D5946642B0CBC7F1");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClienteArticulo>(entity =>
            {
                entity.HasKey(e => e.IdClienteArticulo)
                    .HasName("PK__ClienteA__97A01AB30DF56478");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.ClienteArticulo)
                    .HasForeignKey(d => d.IdArticulo)
                    .HasConstraintName("FK__ClienteAr__IdArt__36B12243");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ClienteArticulo)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__ClienteAr__IdCli__35BCFE0A");
            });

            modelBuilder.Entity<Colonia>(entity =>
            {
                entity.HasKey(e => e.IdColonia)
                    .HasName("PK__Colonia__A1580F6673BC3984");

                entity.Property(e => e.CodigoPostal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.Colonia)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK__Colonia__IdMunic__15502E78");
            });

            modelBuilder.Entity<DireccionCliente>(entity =>
            {
                entity.HasKey(e => e.IdDireccion)
                    .HasName("PK__Direccio__1F8E0C76F29AB46B");

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroInterior)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroeExterior)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.DireccionCliente)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Direccion__IdCli__1DE57479");

                entity.HasOne(d => d.IdColoniaNavigation)
                    .WithMany(p => p.DireccionCliente)
                    .HasForeignKey(d => d.IdColonia)
                    .HasConstraintName("FK__Direccion__IdCol__1CF15040");
            });

            modelBuilder.Entity<DireccionTienda>(entity =>
            {
                entity.HasKey(e => e.IdDireccion)
                    .HasName("PK__Direccio__1F8E0C762D591EFC");

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroInterior)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroeExterior)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdColoniaNavigation)
                    .WithMany(p => p.DireccionTienda)
                    .HasForeignKey(d => d.IdColonia)
                    .HasConstraintName("FK__Direccion__IdCol__267ABA7A");

                entity.HasOne(d => d.IdTiendaNavigation)
                    .WithMany(p => p.DireccionTienda)
                    .HasForeignKey(d => d.IdTienda)
                    .HasConstraintName("FK__Direccion__IdTie__276EDEB3");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado__FBB0EDC1AEEF2C95");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.HasKey(e => e.IdMunicipio)
                    .HasName("PK__Municipi__6100597877B6A0E9");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Municipio)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__Municipio__IdEst__1273C1CD");
            });

            modelBuilder.Entity<Tienda>(entity =>
            {
                entity.HasKey(e => e.IdTienda)
                    .HasName("PK__Tienda__5A1EB96B502D5F44");

                entity.Property(e => e.Sucursal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97D195CBB4");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D10534226542FA")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__IdClien__5629CD9C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
