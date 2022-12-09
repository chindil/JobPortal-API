using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stx.Shared;
using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.Api.Hrm.EntityConfigurations
{
    public class HrJobSkillConfiguration : IEntityTypeConfiguration<HrJobSkill>
    {
        public void Configure(EntityTypeBuilder<HrJobSkill> builder)
        {
            builder.ToTable(nameof(HrJobSkill));
            builder.HasKey(ba => new { ba.Name });
            builder.Property(p => p.Active).HasDefaultValue(true);
            builder.Property(p => p.CreatedOn).HasDefaultValueSql("getdate()");

            //get data from db: SELECT CONCAT('new HrJobIndustry { ID = ',id,', Name = "',name,'", Active = true},') FROM HrJobIndustry
            //builder.HasData
            //(
            //    new HrJobIndustry { ID = 1, Name = "Accounting", Active = true },
            //    new HrJobIndustry { ID = 2, Name = "Administration & Office Support", Active = true },
            //    new HrJobIndustry { ID = 3, Name = "Advertising, Arts & Media", Active = true },
            //    new HrJobIndustry { ID = 4, Name = "Banking & Financial Services", Active = true },
            //    new HrJobIndustry { ID = 5, Name = "Call Centre & Customer Service", Active = true },
            //    new HrJobIndustry { ID = 6, Name = "CEO & General Management", Active = true },
            //    new HrJobIndustry { ID = 7, Name = "Community Services & Development", Active = true },
            //    new HrJobIndustry { ID = 8, Name = "Construction", Active = true },
            //    new HrJobIndustry { ID = 9, Name = "Consulting & Strategy", Active = true },
            //    new HrJobIndustry { ID = 10, Name = "Design & Architecture", Active = true },
            //    new HrJobIndustry { ID = 11, Name = "Education & Training", Active = true },
            //    new HrJobIndustry { ID = 12, Name = "Engineering", Active = true },
            //    new HrJobIndustry { ID = 13, Name = "Farming, Animals & Conservation", Active = true },
            //    new HrJobIndustry { ID = 14, Name = "Government & Defence", Active = true },
            //    new HrJobIndustry { ID = 15, Name = "Healthcare & Medical", Active = true },
            //    new HrJobIndustry { ID = 16, Name = "Hospitality & Tourism", Active = true },
            //    new HrJobIndustry { ID = 17, Name = "Human Resources & Recruitment", Active = true },
            //    new HrJobIndustry { ID = 18, Name = "Information & Communication Technology", Active = true },
            //    new HrJobIndustry { ID = 19, Name = "Insurance & Superannuation", Active = true },
            //    new HrJobIndustry { ID = 20, Name = "Legal", Active = true },
            //    new HrJobIndustry { ID = 21, Name = "Manufacturing, Transport & Logistics", Active = true },
            //    new HrJobIndustry { ID = 22, Name = "Marketing & Communications", Active = true },
            //    new HrJobIndustry { ID = 23, Name = "Mining, Resources & Energy", Active = true },
            //    new HrJobIndustry { ID = 24, Name = "Real Estate & Property", Active = true },
            //    new HrJobIndustry { ID = 25, Name = "Retail & Consumer Products", Active = true },
            //    new HrJobIndustry { ID = 26, Name = "Sales", Active = true },
            //    new HrJobIndustry { ID = 27, Name = "Science & Technology", Active = true },
            //    new HrJobIndustry { ID = 28, Name = "Self Employment", Active = true },
            //    new HrJobIndustry { ID = 29, Name = "Sport & Recreation", Active = true },
            //    new HrJobIndustry { ID = 30, Name = "Trades & Services", Active = true }
            //);
        }
    }
}

