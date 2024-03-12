using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RovisianServerDev.Domain.Entities;


namespace RovisianServerDev.Infrastructure.Data.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> entity)
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

            entity.Property(e => e.Id).HasColumnName("UsuarioId").HasDefaultValueSql("(newid())");

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
        }
    }
}
