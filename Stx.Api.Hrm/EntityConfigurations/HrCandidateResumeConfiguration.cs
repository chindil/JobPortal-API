using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stx.Shared.Models.HRM;

namespace Stx.Api.Hrm.EntityConfigurations
{
    public class HrCandidateCertificateConfiguration : IEntityTypeConfiguration<HrCandidateCertificate>
    {
        public void Configure(EntityTypeBuilder<HrCandidateCertificate> builder)
        {
            builder.ToTable("HrCandidateCertificate");
            builder.HasKey(ba => new { ba.ID, ba.CandidateID });
            builder.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();
        }
    }

    public class HrCandidateEducationConfiguration : IEntityTypeConfiguration<HrCandidateEducation>
    {
        public void Configure(EntityTypeBuilder<HrCandidateEducation> builder)
        {
            builder.ToTable("HrCandidateEducation");
            builder.HasKey(ba => new { ba.ID, ba.CandidateID });
            builder.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();
        }
    }

    public class HrCandidateExperienceConfiguration : IEntityTypeConfiguration<HrCandidateExperience>
    {
        public void Configure(EntityTypeBuilder<HrCandidateExperience> builder)
        {
            builder.ToTable("HrCandidateExperience");
            builder.HasKey(ba => new { ba.ID, ba.CandidateID });
            builder.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(p => p.Salary).HasColumnType("NUMERIC(19,2)");
            builder.Property(p => p.Bonus).HasColumnType("NUMERIC(19,2)");
            builder.Property(p => p.Commission).HasColumnType("NUMERIC(19,2)");
        }
    }

    public class HrCandidateSkillConfiguration : IEntityTypeConfiguration<HrCandidateSkill>
    {
        public void Configure(EntityTypeBuilder<HrCandidateSkill> builder)
        {
            builder.ToTable("HrCandidateSkill");
            builder.HasKey(ba => new { ba.ID, ba.CandidateID });
            builder.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();
        }
    }

    public class HrCandidateLanguageConfiguration : IEntityTypeConfiguration<HrCandidateLanguage>
    {
        public void Configure(EntityTypeBuilder<HrCandidateLanguage> builder)
        {
            builder.ToTable("HrCandidateLanguage");
            builder.HasKey(ba => new { ba.ID, ba.CandidateID });
            builder.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();
        }
    }
}


