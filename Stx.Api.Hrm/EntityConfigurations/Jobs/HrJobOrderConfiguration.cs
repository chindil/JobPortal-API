using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stx.Shared.Models.HRM;

namespace Stx.Api.Hrm.EntityConfigurations.Jobs
{
    public class HrJobOrderConfiguration : IEntityTypeConfiguration<HrJobOrder>
    {
        public void Configure(EntityTypeBuilder<HrJobOrder> builder)
        {
            builder.ToTable(nameof(HrJobOrder));
            builder.HasKey(ba => new { ba.JobOrderID });
            builder.Property(p => p.JobOrderID).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(p => p.Salary).HasColumnType("NUMERIC(19,2)");
            builder.Property(p => p.SalaryTo).HasColumnType("NUMERIC(19,2)");
            builder.Property(p => p.JobHoursPerWeek).HasColumnType("NUMERIC(6,2)");
            //e.Property(p => p.MinYearsExpRequired).HasColumnType("NUMERIC(6,2)");
            builder.Property(p => p.Latitude).HasColumnType("NUMERIC(9,6)");
            builder.Property(p => p.Longitude).HasColumnType("NUMERIC(9,6)");
            builder.Property(p => p.BillingRate).HasColumnType("NUMERIC(19,2)");
            builder.Property(p => p.DateAdded).HasDefaultValueSql("getdate()");
        }
    }
}
