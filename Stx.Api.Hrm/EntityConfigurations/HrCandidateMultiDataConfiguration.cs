using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stx.Shared.Models.HRM;

namespace Stx.Api.Hrm.EntityConfigurations
{
    public class HrCandidateMultiDataConfiguration : IEntityTypeConfiguration<HrCandidateMultiData>
    {
        public void Configure(EntityTypeBuilder<HrCandidateMultiData> builder)
        {
            builder.ToTable(nameof(HrCandidateMultiData));
            builder.HasKey(ba => new { ba.ID });
            builder.HasIndex(p => new { p.CandidateID, p.RecordType, p.EntityValue}).IsUnique();
            builder.Property(p => p.CandidateID).IsRequired();
            builder.Property(p => p.RecordType).IsRequired();
            builder.Property(p => p.EntityValue).IsRequired();
            builder.Property(p => p.DateUpdated).HasDefaultValueSql("GETDATE()");
                        
        }
    }
}
