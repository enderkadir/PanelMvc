using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBlog.Models.Mapping
{
    public class ZiyaretciIPLogMap : EntityTypeConfiguration<ZiyaretciIPLog>
    {
        public ZiyaretciIPLogMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IPAdpress, t.Tarih });

            // Properties
            this.Property(t => t.IPAdpress)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("ZiyaretciIPLog");
            this.Property(t => t.IPAdpress).HasColumnName("IPAdpress");
            this.Property(t => t.Tarih).HasColumnName("Tarih");
        }
    }
}
