using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BISolutions.Models;

namespace BISolutions.DataContext
{
    public class Rol_UsuarioMapping// : IEntityTypeConfiguration<Rol_Usuario>
    {/*
        public void Configure(EntityTypeBuilder<Rol_Usuario> builder)
        {
            builder.ToTable("Rol_Usuario", "dbo");
            builder.HasKey(q => q.rol_usuario_id);
            builder.Property(e => e.rol_usuario_id).IsRequired().UseIdentityColumn();

            builder.HasOne(e => e.Rol)
                .WithMany(e => e.Roles_Usuarios)
                .HasForeignKey(e => e.rol_id);
            builder.HasOne(e => e.Usuario)
                .WithMany(e => e.Roles_Usuarios)
                .HasForeignKey(e => e.usuario_id);
        }*/
    }
}
