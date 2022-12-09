using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stx.Shared.Models.HRM;

namespace Stx.Api.Hrm.EntityConfigurations
{
    public class HrCandidateJobBookmarkConfiguration : IEntityTypeConfiguration<HrCandidateJobBookmark>
    {
        public void Configure(EntityTypeBuilder<HrCandidateJobBookmark> builder)
        {
            builder.ToTable(nameof(HrCandidateJobBookmark));
            builder.HasKey(ba => new { ba.ID });
            builder.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();
        }
    }
}
