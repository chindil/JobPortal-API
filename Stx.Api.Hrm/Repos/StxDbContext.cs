using System;
using Stx.Shared;
using Microsoft.EntityFrameworkCore;
using Stx.Shared.Models;
using Stx.Shared.Models.HRM;
using Stx.Shared.Reports;
using Stx.Shared.Bps;
using Stx.Shared.Ips;
using Stx.Shared.Models.CRM;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Stx.Api.Hrm.EntityConfigurations;
using Stx.Api.Hrm.EntityConfigurations.Jobs;

namespace Stx.Api.Hrm.Repos
{
    public class StxDbContext : IdentityDbContext<ApplicationUser>
    {
        public StxDbContext(DbContextOptions<StxDbContext> options) : base(options)
        {

        }

		#region General
		public DbSet<Country> Countries { get; set; }
		public DbSet<State> States { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Nationality> Nationalities { get; set; }
		public DbSet<Lang> Languages{ get; set; }
		public DbSet<Currency> Currencies { get; set; }
		public DbSet<UserProfile> UserProfiles { get; set; }
		#endregion

		#region CRM
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Corporate> Corporates { get; set; }
        public DbSet<CorporateBenchmark> CorporateBenchmarks { get; set; }
        public DbSet<CorporatePreference> CorporatePreferences{ get; set; }

        #endregion

        #region HRM
        public DbSet<HrEmployee> Employees { get; set; }

        public DbSet<HrJobOrder> HrJobOrders { get; set; }
        public DbSet<HrJobSendout> HrJobSendouts { get; set; }
        public DbSet<HrJobIndustry> HrJobIndustries { get; set; }
        public DbSet<HrJobCategory> HrJobCategories { get; set; }
        public DbSet<HrJobSpecialty> HrJobSpecialties { get; set; }
        public DbSet<HrJobSkill> HrJobSkills { get; set; }
        public DbSet<HrReviewQuestion> HrReviewQuestions { get; set; }
        public DbSet<HrJobHiringTeam> HrJobHiringTeams { get; set; }

        public DbSet<HrCandidate> HrCandidates { get; set; }
        public DbSet<HrCandidateCertificate> HrCandidateCertificates { get; set; }
        public DbSet<HrCandidateEducation> HrCandidateEducations { get; set; }
        public DbSet<HrCandidateExperience> HrCandidateExperiences { get; set; }
        public DbSet<HrCandidateSkill> HrCandidateSkills { get; set; }
        public DbSet<HrCandidateLanguage> HrCandidateLanguages { get; set; }
        public DbSet<HrCandidateJobBookmark> HrCandidateJobBookmarks { get; set; }
        public DbSet<HrCandidateJobActivity> HrCandidateJobActivities { get; set; }
        public DbSet<HrCandidateMultiData> HrCandidateMultiDatas { get; set; }

        public DbSet<HrJobCandidate> HrJobCandidates { get; set; }
        public DbSet<HrAtsDepartment> HrAtsDepartments{ get; set; }
        public DbSet<HrAtsTeam> HrAtsTeams { get; set; }
        public DbSet<HrAtsTeamJob> HrAtsTeamJobs { get; set; }
        public DbSet<HrAtsMailTemplate> HrAtsMailTemplates{ get; set; }
        public DbSet<HrAtsWorkflow> HrAtsWorkflows { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region General
            modelBuilder.Entity<Country>().HasKey(ba => new { ba.CountryID });

            modelBuilder.Entity<State>(e => { 
                e.HasKey(ba => new { ba.StateID, ba.CountryID });
                e.Property(p => p.Active).HasDefaultValue(true);
            });
            modelBuilder.Entity<City>(e =>
            {
                e.HasKey(ba => new { ba.CityID });
                e.Property(p => p.Active).HasDefaultValue(true);
            });
            modelBuilder.Entity<Nationality>(e =>
            {
                e.HasKey(ba => new { ba.NationalityID });
                e.Property(p => p.Active).HasDefaultValue(true);
            });
            modelBuilder.Entity<Lang>(e =>
            {
                e.HasKey(ba => new { ba.LangID });
                e.Property(p => p.Active).HasDefaultValue(true); e.Property(p => p.HasWrittenLang).HasDefaultValue(true);
            });
            modelBuilder.Entity<Currency>(e =>
            {
                e.HasKey(ba => new { ba.CurrCD });
                e.Property(p => p.Active).HasDefaultValue(true);
                e.Property(p => p.RoundSys).HasColumnType("NUMERIC(18,2)");
            });
            modelBuilder.Entity<UserProfile>(e =>
            {
                e.HasKey(ba => new { ba.UserName });
                e.Property(p => p.IsRegistered).HasDefaultValue(true);
                e.Property(p => p.IsCandidate).HasDefaultValue(true);
                e.Property(p => p.IsCorporateUser).HasDefaultValue(true);
            });
            #endregion

            #region CRM
            modelBuilder.Entity<Corporate>(e =>
            {
                e.HasKey(ba => new { ba.CorporateID });
                e.HasIndex(e => e.UserName).IsUnique();
                e.Property(e => e.Active).HasDefaultValue(true);
            });
            modelBuilder.Entity<CorporateDTO>(e =>
            {
                e.HasNoKey().ToTable(nameof(CorporateDTO), t=> t.ExcludeFromMigrations());
                e.Property(p => p.Salary).HasColumnType("NUMERIC(19,2)");
                e.Property(p => p.SalaryTo).HasColumnType("NUMERIC(19,2)");
                e.Property(p => p.JobHoursPerWeek).HasColumnType("NUMERIC(6,2)");
                e.Property(p => p.MinYearsExpRequired).HasColumnType("NUMERIC(6,2)");
            });
            modelBuilder.Entity<CorporatePublicDTO>(e =>
            {
                e.HasNoKey().ToTable(nameof(CorporatePublicDTO), t=> t.ExcludeFromMigrations());
            });
            modelBuilder.Entity<CorporateBenchmark>(e =>
            {
                e.HasKey(ba => new { ba.ID });
                e.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();
                e.HasIndex(ba => new { ba.ModuelID, ba.CorporateID, ba.BmkCategory, ba.BmkAttribute }).IsUnique();
                e.Property(p => p.SeqNum).HasDefaultValue(0);
            }); 
            modelBuilder.Entity<CorporatePreference>(e =>
            {
                e.HasKey(ba => new { ba.ID});
                e.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();
                e.HasIndex(p => new { p.ModuelID, p.CorporateID, p.PrefKey }).IsUnique();
                e.Property(p => p.SeqNum).HasDefaultValue(0);
            });
            modelBuilder.Entity<Contact>(e =>
            {
                e.HasKey(ba => new { ba.CompanyID, ba.DocNum });
                e.Property(o => o.DynmBillableAmt).HasColumnType("NUMERIC(19,2)");
                e.Property(p => p.DynmCurrBalance).HasColumnType("NUMERIC(19,2)");
                e.Property(p => p.DynmDueBalance).HasColumnType("NUMERIC(19,2)");
                e.Property(p => p.DynmPaidAmt).HasColumnType("NUMERIC(19,2)");
            });
            #endregion

            #region HRM
            modelBuilder.Entity<HrEmployee>().HasKey(ba => new { ba.EmployeeID });
            
            //Configurations
            modelBuilder.ApplyConfiguration(new HrCandidateConfiguration());
            modelBuilder.ApplyConfiguration(new HrCandidateCertificateConfiguration());
            modelBuilder.ApplyConfiguration(new HrCandidateEducationConfiguration());
            modelBuilder.ApplyConfiguration(new HrCandidateExperienceConfiguration());
            modelBuilder.ApplyConfiguration(new HrCandidateSkillConfiguration());
            modelBuilder.ApplyConfiguration(new HrCandidateLanguageConfiguration());
            
            modelBuilder.ApplyConfiguration(new HrCandidateMultiDataConfiguration());
            modelBuilder.ApplyConfiguration(new HrCandidateJobActivityConfiguration());
            modelBuilder.ApplyConfiguration(new HrCandidateJobBookmarkConfiguration());
            
            modelBuilder.ApplyConfiguration(new HrCandidateJobStatDTOConfiguration());
            modelBuilder.ApplyConfiguration(new HrJobOrderSearchConfiguration()); //HrJobOrderSearchDto
            modelBuilder.ApplyConfiguration(new HrCandidatePublicDTOConfiguration());
            modelBuilder.ApplyConfiguration(new HrJobCandidateListDTOConfiguration());
            
            //Jobs
            modelBuilder.ApplyConfiguration(new HrJobOrderConfiguration());
            modelBuilder.ApplyConfiguration(new HrJobSummaryDTOConfiguration());
            modelBuilder.ApplyConfiguration(new HrJobOrderPreviewDTOConfiguration());
            modelBuilder.ApplyConfiguration(new HrJobSendoutConfiguration());
            modelBuilder.ApplyConfiguration(new HrJobIndustryConfiguration());
            modelBuilder.ApplyConfiguration(new HrJobCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new HrJobSpecialtyConfiguration());
            modelBuilder.ApplyConfiguration(new HrJobSkillConfiguration());

            //HrJobCandidate
            modelBuilder.ApplyConfiguration(new HrJobCandidateConfiguration());
            modelBuilder.ApplyConfiguration(new HrJobCandidateCertificateConfiguration());
            modelBuilder.ApplyConfiguration(new HrJobCandidateEducationConfiguration());
            modelBuilder.ApplyConfiguration(new HrJobCandidateExperienceConfiguration());
            modelBuilder.ApplyConfiguration(new HrJobCandidateSkillConfiguration());
                        
         
            //ATS
            modelBuilder.Entity<HrReviewQuestion>(e =>
            {
                e.HasKey(ba => new {ba.JobOrderID, ba.ID });
                e.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();
                e.Property(p => p.IsAutoEvaluate).HasDefaultValue(false);
            });  
            modelBuilder.Entity<HrJobHiringTeam>(e =>
            {
                e.HasKey(ba => new {ba.CorporateID, ba.JobOrderID , ba.MemberEmail });
                e.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();
                e.Property(p => p.Active).HasDefaultValue(true);
            });

            modelBuilder.Entity<HrAtsDepartment>(e =>
            {
                e.HasKey(ba => new { ba.ID});
                e.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd(); //.Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                e.HasIndex(p => new { p.CorporateID, p.Name }).IsUnique();
                e.Property(p => p.Active).HasDefaultValue(true);
            });
            modelBuilder.Entity<HrAtsTeam>(e =>
            {
                e.HasKey(ba => new { ba.ID });
                e.HasIndex(p => new { p.CorporateID, p.Email }).IsUnique();
                e.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();//.Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                e.Property(p => p.Active).HasDefaultValue(true);
                e.Property(p => p.IsReqAccepted).HasDefaultValue(false);
            });  
            modelBuilder.Entity<HrAtsTeamJob>(e =>
            {
                e.HasKey(ba => new { ba.CorporateID, ba.CorpUserID, ba.JobOrderID });
                e.Property(p => p.Active).HasDefaultValue(true);
            });
            modelBuilder.Entity<HrAtsMailTemplate>(e =>
            {
                e.HasKey(ba => new { ba.ID});
                e.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();//.Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                e.HasIndex(p => new { p.CorporateID, p.Name }).IsUnique();
                e.Property(p => p.Active).HasDefaultValue(true);
            });  
            modelBuilder.Entity<HrAtsWorkflow>(e =>
            {
                e.HasKey(ba => new { ba.ID});
                e.Property(p => p.ID).UseIdentityColumn().ValueGeneratedOnAdd();//.Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                e.HasIndex(p => new { p.CorporateID, p.Name }).IsUnique();
                e.Property(p => p.IsConfidential).HasDefaultValue(false);
                e.Property(p => p.IsLocked).HasDefaultValue(false);
            });
            #endregion

        }
    }
}
