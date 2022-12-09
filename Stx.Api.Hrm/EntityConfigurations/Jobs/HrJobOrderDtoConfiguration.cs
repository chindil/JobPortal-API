using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stx.Shared.Models.HRM;

namespace Stx.Api.Hrm.EntityConfigurations.Jobs
{
    public class HrJobSummaryDTOConfiguration : IEntityTypeConfiguration<HrJobSummaryDTO>
    {
        public void Configure(EntityTypeBuilder<HrJobSummaryDTO> builder)
        {
            builder.HasNoKey().ToTable(nameof(HrJobSummaryDTO), t => t.ExcludeFromMigrations());
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
        }
    }

    public class HrJobOrderPreviewDTOConfiguration : IEntityTypeConfiguration<HrJobOrderPreviewDTO>
    {
        public void Configure(EntityTypeBuilder<HrJobOrderPreviewDTO> builder)
        {
            builder.HasNoKey().ToTable(nameof(HrJobOrderPreviewDTO), t => t.ExcludeFromMigrations());
            builder.Property(p => p.Salary).HasColumnType("NUMERIC(19,2)");
            builder.Property(p => p.SalaryTo).HasColumnType("NUMERIC(19,2)");
            builder.Property(p => p.JobHoursPerWeek).HasColumnType("NUMERIC(6,2)");
        }
    }

}

