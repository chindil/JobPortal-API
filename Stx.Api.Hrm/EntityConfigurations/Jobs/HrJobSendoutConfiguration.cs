using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stx.Shared.Models.HRM;

namespace Stx.Api.Hrm.EntityConfigurations.Jobs
{
    public class HrJobSendoutConfiguration : IEntityTypeConfiguration<HrJobSendout>
    {
        public void Configure(EntityTypeBuilder<HrJobSendout> builder)
        {
            builder.ToTable(nameof(HrJobSendout));
            builder.HasKey(ba => new { ba.ID });
            builder.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(p => p.Active).HasDefaultValue(true);
            builder.Property(p => p.DateAdded).HasDefaultValueSql("getdate()");
        }
    }
}
