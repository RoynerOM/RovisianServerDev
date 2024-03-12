﻿using Microsoft.EntityFrameworkCore;
using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Infrastructure.Data
{
    public partial class RovisianDBContext : DbContext
    {
        public RovisianDBContext()
        {
        }

        public RovisianDBContext(DbContextOptions<RovisianDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BancoEntity> Bancos { get; set; } = null!;
        public virtual DbSet<CasoEntity> Casos { get; set; } = null!;
        public virtual DbSet<EstadoEntity> Estados { get; set; } = null!;
        public virtual DbSet<InstitucionEntity> Institucions { get; set; } = null!;
        public virtual DbSet<RolEntity> Roles { get; set; } = null!;
        public virtual DbSet<RutaEntity> Rutas { get; set; } = null!;
        public virtual DbSet<TipoInstitucionEntity> TipoInstituciones { get; set; } = null!;
        public virtual DbSet<UsuarioEntity> Usuarios { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BancoEntity>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__tBanco__4A8BAFF57FC62C99");

                entity.ToTable("tBanco");

                entity.HasIndex(e => e.Nombre, "UQ_nombre_banco")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("BancoId").HasDefaultValueSql("(newid())");

                entity.Property(e => e.Borrado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CasoEntity>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__tCaso__692E7553B39A4F2B");

                entity.ToTable("tCaso");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Borrado).HasDefaultValueSql("((0))");

                entity.Property(e => e.CodigoCaso)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('R-'+CONVERT([nvarchar](6),NEXT VALUE FOR [SecuenciaCasos]-(1)))");

                entity.Property(e => e.Secuencia).HasDefaultValueSql("(NEXT VALUE FOR [SecuenciaCasos])");

                entity.HasOne(d => d.Contador)
                    .WithMany(p => p.CasoContadors)
                    .HasForeignKey(d => d.ContadorId)
                    .HasConstraintName("FK__tCaso__ContadorI__3493CFA7");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Casos)
                    .HasForeignKey(d => d.EstadoId)
                    .HasConstraintName("FK__tCaso__EstadoId__3587F3E0");

                entity.HasOne(d => d.Institucion)
                    .WithMany(p => p.Casos)
                    .HasForeignKey(d => d.InstitucionId)
                    .HasConstraintName("FK__tCaso__Instituci__32AB8735");

                entity.HasOne(d => d.Tramitador)
                    .WithMany(p => p.CasoTramitadors)
                    .HasForeignKey(d => d.TramitadorId)
                    .HasConstraintName("FK__tCaso__Tramitado__339FAB6E");
            });

            modelBuilder.Entity<EstadoEntity>(entity =>
            {
                entity.ToTable("tEstado");

                entity.HasIndex(e => e.Nombre, "UQ_nombre_estado")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Borrado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InstitucionEntity>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__tInstitu__706D41C9DCD4EEC7");

                entity.ToTable("tInstitucion");

                entity.HasIndex(e => e.CedulaJuridica, "UQ_cj_institucion")
                    .IsUnique();

                entity.HasIndex(e => e.Codigo, "UQ_cod_institucion")
                    .IsUnique();

                entity.HasIndex(e => e.Nombre, "UQ_nombre_institucion")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Borrado).HasDefaultValueSql("((0))");

                entity.Property(e => e.CedulaJuridica)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Circuito).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cuenta6746)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CuentaDanea)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre).HasMaxLength(255);

                entity.Property(e => e.Responsable)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Banco)
                    .WithMany(p => p.Instituciones)
                    .HasForeignKey(d => d.BancoId)
                    .HasConstraintName("FK__tInstituc__Banco__1EA48E88");

                entity.HasOne(d => d.Contador)
                    .WithMany(p => p.Instituciones)
                    .HasForeignKey(d => d.ContadorId)
                    .HasConstraintName("FK__tInstituc__Conta__2180FB33");

                entity.HasOne(d => d.Ruta)
                    .WithMany(p => p.Instituciones)
                    .HasForeignKey(d => d.RutaId)
                    .HasConstraintName("FK__tInstituc__RutaI__1F98B2C1");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Instituciones)
                    .HasForeignKey(d => d.TipoId)
                    .HasConstraintName("FK__tInstituc__TipoI__208CD6FA");
            });

            modelBuilder.Entity<RolEntity>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__tRol__F92302F18726AA9E");

                entity.ToTable("tRol");

                entity.HasIndex(e => e.Nombre, "UQ_nombre_rol")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("RolId").HasDefaultValueSql("(newid())");

                entity.Property(e => e.Borrado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RutaEntity>(entity =>
            {
                entity.HasKey(e => e.RutaId)
                    .HasName("PK__tRuta__7B61998EB189A792");

                entity.ToTable("tRuta");

                entity.HasIndex(e => e.Nombre, "UQ_nombre_ruta")
                    .IsUnique();

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoInstitucionEntity>(entity =>
            {
                entity.HasKey(e => e.TipoId)
                    .HasName("PK__tTipoIns__97099EB7F8B6DF05");

                entity.ToTable("tTipoInstitucion");

                entity.HasIndex(e => e.Nombre, "UQ_nombre_tipoins")
                    .IsUnique();

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<UsuarioEntity>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__tUsuario__2B3DE7B852F4EF0C");

                entity.ToTable("tUsuario");

                entity.HasIndex(e => e.Carnet, "UQ_carnet_usuario")
                    .IsUnique();

                entity.HasIndex(e => e.Cedula, "UQ_cedula_usuario")
                    .IsUnique();

                entity.HasIndex(e => e.Correo, "UQ_correo_usuario")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Apellidos).HasMaxLength(150);

                entity.Property(e => e.Borrado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Carnet)
                    .HasMaxLength(20)
                    .HasColumnName("carnet")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Cedula).HasMaxLength(18);

                entity.Property(e => e.Contrasenna).HasMaxLength(64);

                entity.Property(e => e.Correo).HasMaxLength(150);

                entity.Property(e => e.Firma).HasMaxLength(32);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.UtimaVez)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK__tUsuario__RolId__07C12930");
            });

            modelBuilder.HasSequence<int>("SecuenciaCasos");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
