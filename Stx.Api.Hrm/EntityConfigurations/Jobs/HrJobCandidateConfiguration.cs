using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stx.Shared.Models.HRM;

namespace Stx.Api.Hrm.EntityConfigurations.Jobs
{
    public class HrJobCandidateConfiguration : IEntityTypeConfiguration<HrJobCandidate>
    {
        public void Configure(EntityTypeBuilder<HrJobCandidate> builder)
        {
            builder.ToTable(nameof(HrJobCandidate));
            builder.HasKey(ba => new { ba.JobCandidateID });
            builder.Property(p => p.JobCandidateID).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(p => p.ExpectedSalary).HasColumnType("NUMERIC(19,2)");
            builder.Property(p => p.ExpectedSalaryLow).HasColumnType("NUMERIC(19,2)");

            builder.HasMany<HrJobCandidateCertificate>(g => g.Certificates)
                .WithOne()//s => s.Candidate
                .HasForeignKey(s => s.JobCandidateID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<HrJobCandidateEducation>(g => g.Educations)
                .WithOne()//s => s.Candidate
                .HasForeignKey(s => s.JobCandidateID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<HrJobCandidateExperience>(g => g.Experiences)
                .WithOne()//s => s.Candidate
                .HasForeignKey(s => s.JobCandidateID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<HrJobCandidateSkill>(g => g.Skills)
                .WithOne()//s => s.Candidate
                .HasForeignKey(s => s.JobCandidateID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class HrJobCandidateCertificateConfiguration : IEntityTypeConfiguration<HrJobCandidateCertificate>
    {
        public void Configure(EntityTypeBuilder<HrJobCandidateCertificate> builder)
        {
            builder.ToTable(nameof(HrJobCandidateCertificate));
            builder.HasKey(ba => new { ba.ID, ba.JobCandidateID });
            builder.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();
        }
    }
    public class HrJobCandidateEducationConfiguration : IEntityTypeConfiguration<HrJobCandidateEducation>
    {
        public void Configure(EntityTypeBuilder<HrJobCandidateEducation> builder)
        {
            builder.ToTable(nameof(HrJobCandidateEducation));
            builder.HasKey(ba => new { ba.ID, ba.JobCandidateID });
            builder.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();
        }
    }  
    
    public class HrJobCandidateExperienceConfiguration : IEntityTypeConfiguration<HrJobCandidateExperience>
    {
        public void Configure(EntityTypeBuilder<HrJobCandidateExperience> builder)
        {
            builder.ToTable(nameof(HrJobCandidateExperience));
            builder.HasKey(ba => new { ba.ID, ba.JobCandidateID });
            builder.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(p => p.Salary).HasColumnType("NUMERIC(19,2)");
            builder.Property(p => p.Bonus).HasColumnType("NUMERIC(19,2)");
            builder.Property(p => p.Commission).HasColumnType("NUMERIC(19,2)");
        }
    }
    public class HrJobCandidateSkillConfiguration : IEntityTypeConfiguration<HrJobCandidateSkill>
    {
        public void Configure(EntityTypeBuilder<HrJobCandidateSkill> builder)
        {
            builder.ToTable(nameof(HrJobCandidateSkill));
            builder.HasKey(ba => new { ba.JobCandidateID, ba.SkillName });
            builder.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }

}
