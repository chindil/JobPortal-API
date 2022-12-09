using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stx.Shared.Models.HRM;

namespace Stx.Api.Hrm.EntityConfigurations
{
    public class HrCandidateConfiguration : IEntityTypeConfiguration<HrCandidate>
    {
        public void Configure(EntityTypeBuilder<HrCandidate> builder)
        {
            builder.ToTable(nameof(HrCandidate));
            builder.HasKey(ba => new { ba.CandidateID });
            builder.HasIndex(p => p.UserName).IsUnique();
            builder.Property(p => p.ExpectedSalary).HasColumnType("NUMERIC(19,2)");
            builder.Property(p => p.ExpectedSalaryLow).HasColumnType("NUMERIC(19,2)");

            builder.HasMany<HrCandidateCertificate>(g => g.Certificates)
                .WithOne()//s => s.Candidate
                .HasForeignKey(s => s.CandidateID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<HrCandidateEducation>(g => g.Educations)
                .WithOne()//s => s.Candidate
                .HasForeignKey(s => s.CandidateID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<HrCandidateExperience>(g => g.Experiences)
                .WithOne()//s => s.Candidate
                .HasForeignKey(s => s.CandidateID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<HrCandidateSkill>(g => g.Skills)
                .WithOne()//s => s.Candidate
                .HasForeignKey(s => s.CandidateID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<HrCandidateLanguage>(g => g.Languages)
                .WithOne()//s => s.Candidate
                .HasForeignKey(s => s.CandidateID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
