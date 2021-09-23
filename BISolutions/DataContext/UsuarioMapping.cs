using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BISolutions.Models;

namespace BISolutions.DataContext
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "dbo");
            builder.HasKey(q => q.usuario_id);
            builder.Property(e => e.usuario_id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.usuario_nombre).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.usuario_correo).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.usuario_contrasena).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.usuario_sal).HasColumnType("nvarchar(max)");

            builder.HasOne(e => e.Rol)
                .WithMany(e => e.Usuarios)
                .HasForeignKey(e => e.usuario_rol_id);
        }
    }
}
