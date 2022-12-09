using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stx.Shared.Models.HRM;

namespace Stx.Api.Hrm.EntityConfigurations
{
    public class HrCandidateJobActivityConfiguration : IEntityTypeConfiguration<HrCandidateJobActivity>
    {
        public void Configure(EntityTypeBuilder<HrCandidateJobActivity> builder)
        {
            builder.ToTable(nameof(HrCandidateJobActivity));
            builder.HasKey(ba => new { ba.ID });
            builder.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();
        }
    }
}
