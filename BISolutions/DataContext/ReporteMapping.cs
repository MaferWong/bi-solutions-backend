using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BISolutions.Models;

namespace BISolutions.DataContext
{
    public class ReporteMapping : IEntityTypeConfiguration<Reporte>
    {
        public void Configure(EntityTypeBuilder<Reporte> builder)
        {
            builder.ToTable("Reporte", "dbo");
            builder.HasKey(q => q.reporte_id);
            builder.Property(e => e.reporte_id).IsRequired().UseIdentityColumn();
            builder.Property(e => e.reporte_descripcion).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.reporte_URL).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(e => e.reporte_activo).HasColumnType("nvarchar(10)").IsRequired();
        }
    }
}
