using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BISolutions.Models;

namespace BISolutions.DataContext
{
    public class RolMapping : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rol", "dbo");
            builder.HasKey(q => q.rol_id);
            builder.Property(e => e.rol_id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.rol_descripcion).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
