using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stx.Shared.Models.HRM;

namespace Stx.Api.Hrm.EntityConfigurations
{
    public class HrCandidateJobStatDTOConfiguration : IEntityTypeConfiguration<HrCandidateJobStatDTO>
    {
        public void Configure(EntityTypeBuilder<HrCandidateJobStatDTO> builder)
        {
            builder.HasNoKey().ToTable(nameof(HrCandidateJobStatDTO), t => t.ExcludeFromMigrations());
            builder.Property(p => p.Salary).HasColumnType("NUMERIC(19,2)");
            builder.Property(p => p.SalaryTo).HasColumnType("NUMERIC(19,2)");
        }
    }

    public class HrJobOrderSearchConfiguration : IEntityTypeConfiguration<HrJobOrderSearch>
    {
        public void Configure(EntityTypeBuilder<HrJobOrderSearch> builder)
        {
            builder.HasNoKey().ToTable(nameof(HrJobOrderSearch), t => t.ExcludeFromMigrations());
            builder.Property(p => p.Salary).HasColumnType("NUMERIC(19,2)");
            builder.Property(p => p.SalaryTo).HasColumnType("NUMERIC(19,2)");
            builder.Property(p => p.JobHoursPerWeek).HasColumnType("NUMERIC(19,2)");
        }
    }

    public class HrCandidatePublicDTOConfiguration : IEntityTypeConfiguration<HrCandidatePublicDTO>
    {
        public void Configure(EntityTypeBuilder<HrCandidatePublicDTO> builder)
        {
            builder.HasNoKey().ToTable(nameof(HrCandidatePublicDTO), t=> t.ExcludeFromMigrations());
            builder.Property(p => p.Active).HasDefaultValue(true);
            builder.Property(p => p.ExpectedSalary).HasColumnType("NUMERIC(9,6)");
        }
    }

    public class HrJobCandidateListDTOConfiguration : IEntityTypeConfiguration<HrJobCandidateListDTO>
    {
        public void Configure(EntityTypeBuilder<HrJobCandidateListDTO> builder)
        {
            builder.HasNoKey().ToTable(nameof(HrJobCandidateListDTO), t => t.ExcludeFromMigrations());
        }
    }
}

