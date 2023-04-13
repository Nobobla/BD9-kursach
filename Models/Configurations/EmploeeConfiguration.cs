using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BD9.Models.Configurations
{
    public class EmploeeConfiguration : IEntityTypeConfiguration<Emploee>
    {
        public void Configure(EntityTypeBuilder<Emploee> builder)
        {
            builder.HasKey(x => x.id);
            builder
                .HasOne(x => x.ContactInform)
                .WithOne(y => y.Emploee)
                .HasForeignKey<ContactInform>(y => y.EmploeeId);
        }
    }
}
