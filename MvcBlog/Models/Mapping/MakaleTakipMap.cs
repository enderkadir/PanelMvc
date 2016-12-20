using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MvcBlog.Models.Mapping
{
    public class MakaleTakipMap : EntityTypeConfiguration<MakaleTakip>
    {
        public MakaleTakipMap()
        {
            // Primary Key
            this.HasKey(t => t.MakaleID);

            // Properties
            this.Property(t => t.MakaleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MailAdresi)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("MakaleTakip");
            this.Property(t => t.MakaleID).HasColumnName("MakaleID");
            this.Property(t => t.MailAdresi).HasColumnName("MailAdresi");

            // Relationships
            this.HasRequired(t => t.Makale)
                .WithOptional(t => t.MakaleTakip);

        }
    }
}
