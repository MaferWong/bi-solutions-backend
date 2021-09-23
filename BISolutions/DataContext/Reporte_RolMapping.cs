using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BISolutions.Models;

namespace BISolutions.DataContext
{
    public class Reporte_RolMapping : IEntityTypeConfiguration<Reporte_Rol>
    {
        public void Configure(EntityTypeBuilder<Reporte_Rol> builder)
        {
            builder.ToTable("Reporte_Rol", "dbo");
            builder.HasKey(q => q.reporte_rol_id);
            builder.Property(e => e.reporte_rol_id).IsRequired().UseIdentityColumn();

            builder.HasOne(e => e.Rol)
                .WithMany(e => e.Reportes_Roles)
                .HasForeignKey(e => e.rol_id);
            builder.HasOne(e => e.Reporte)
                .WithMany(e => e.Reportes_Roles)
                .HasForeignKey(e => e.reporte_id);
        }
    }
}
