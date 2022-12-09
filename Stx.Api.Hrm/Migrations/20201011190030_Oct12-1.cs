using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class Oct121 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrCorporateCandidate");

            migrationBuilder.DropColumn(
                name: "CandidateSource",
                table: "HrCandidate");

            migrationBuilder.DropColumn(
                name: "LinkedClientContact",
                table: "HrCandidate");

            migrationBuilder.AddColumn<string>(
                name: "LinkedCorpContact",
                table: "HrCandidate",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HrJobCandidate",
                columns: table => new
                {
                    JobCandidateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    NickName = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(maxLength: 1, nullable: true),
                    NamePrefix = table.Column<string>(maxLength: 6, nullable: true),
                    NameSuffix = table.Column<string>(maxLength: 6, nullable: true),
                    Nationality = table.Column<short>(nullable: true),
                    Mobile = table.Column<string>(maxLength: 20, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Phone2 = table.Column<string>(maxLength: 20, nullable: true),
                    WorkPhone = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 150, nullable: true),
                    Email2 = table.Column<string>(maxLength: 150, nullable: true),
                    Fax = table.Column<string>(maxLength: 20, nullable: true),
                    Fax2 = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    Address2 = table.Column<string>(maxLength: 200, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    SecondaryAddress = table.Column<string>(maxLength: 800, nullable: true),
                    JobIndustry = table.Column<short>(nullable: true),
                    ExperienceLevel = table.Column<string>(maxLength: 6, nullable: true),
                    CurrOccupation = table.Column<string>(maxLength: 100, nullable: true),
                    CurrCompanyName = table.Column<string>(maxLength: 100, nullable: true),
                    CurrCompanyURL = table.Column<string>(maxLength: 150, nullable: true),
                    ExpectedSalary = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    ExpectedSalaryLow = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    PreferredLocations = table.Column<string>(maxLength: 100, nullable: true),
                    HighestEduLevel = table.Column<string>(maxLength: 30, nullable: true),
                    SkillSetDesc = table.Column<string>(maxLength: 4000, nullable: true),
                    PrimarySkills = table.Column<string>(maxLength: 500, nullable: true),
                    SecondarySkills = table.Column<string>(maxLength: 500, nullable: true),
                    Specialties = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 3000, nullable: true),
                    Comments = table.Column<string>(maxLength: 3000, nullable: true),
                    TotalExperience = table.Column<int>(nullable: true),
                    MaritalStatus = table.Column<string>(maxLength: 6, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateAvailable = table.Column<DateTime>(nullable: true),
                    DateLastComment = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: true),
                    DateNextCall = table.Column<DateTime>(nullable: true),
                    TimeZoneOffsetEST = table.Column<int>(nullable: true),
                    PreferredContactModes = table.Column<string>(maxLength: 50, nullable: true),
                    JobSearchingMode = table.Column<string>(maxLength: 10, nullable: true),
                    IsMassMailOptOut = table.Column<bool>(nullable: true),
                    IsSmsOptIn = table.Column<bool>(nullable: true),
                    IsWhatsappOptIn = table.Column<bool>(nullable: true),
                    IsMessengerOptIn = table.Column<bool>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    IsEditable = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Privacy = table.Column<short>(nullable: true),
                    IsExempt = table.Column<bool>(nullable: true),
                    ExternalID = table.Column<string>(maxLength: 100, nullable: true),
                    EmploymentPreference = table.Column<string>(maxLength: 50, nullable: true),
                    Disability = table.Column<string>(maxLength: 20, nullable: true),
                    LinkedCorpContact = table.Column<string>(maxLength: 30, nullable: true),
                    Owner = table.Column<string>(maxLength: 50, nullable: true),
                    OnboardingStatus = table.Column<string>(maxLength: 20, nullable: true),
                    Placements = table.Column<string>(maxLength: 20, nullable: true),
                    CandidateSource = table.Column<string>(maxLength: 50, nullable: true),
                    JobOrderID = table.Column<int>(nullable: false),
                    CorporateID = table.Column<int>(nullable: false),
                    CandidateID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrJobCandidate", x => x.JobCandidateID);
                });

            migrationBuilder.CreateTable(
                name: "HrJobCandidateCertificate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCandidateID = table.Column<int>(nullable: false),
                    CertificateName = table.Column<string>(maxLength: 100, nullable: true),
                    LicenseNumber = table.Column<string>(maxLength: 100, nullable: true),
                    LicenseType = table.Column<string>(maxLength: 30, nullable: true),
                    Results = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<string>(maxLength: 30, nullable: true),
                    IssuedBy = table.Column<string>(maxLength: 100, nullable: true),
                    IssuerCountry = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(maxLength: 3000, nullable: true),
                    Comments = table.Column<string>(maxLength: 3000, nullable: true),
                    IsPending = table.Column<bool>(nullable: true),
                    FileAttachments = table.Column<string>(maxLength: 200, nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    DateCertified = table.Column<DateTime>(nullable: true),
                    DateExpiration = table.Column<DateTime>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateLastModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrJobCandidateCertificate", x => new { x.ID, x.JobCandidateID });
                    table.ForeignKey(
                        name: "FK_HrJobCandidateCertificate_HrJobCandidate_JobCandidateID",
                        column: x => x.JobCandidateID,
                        principalTable: "HrJobCandidate",
                        principalColumn: "JobCandidateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HrJobCandidateEducation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCandidateID = table.Column<int>(nullable: false),
                    Institute = table.Column<string>(maxLength: 100, nullable: true),
                    InstituteUnit = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<short>(nullable: true),
                    City = table.Column<short>(nullable: true),
                    QualificationName = table.Column<string>(maxLength: 100, nullable: true),
                    QualificationType = table.Column<string>(maxLength: 30, nullable: true),
                    FieldOfStudy = table.Column<string>(maxLength: 50, nullable: true),
                    DateGraduated = table.Column<DateTime>(nullable: false),
                    DateStarted = table.Column<DateTime>(nullable: false),
                    DateExpiration = table.Column<DateTime>(nullable: false),
                    Major = table.Column<string>(maxLength: 100, nullable: true),
                    Grade = table.Column<string>(maxLength: 30, nullable: true),
                    Gpa = table.Column<double>(nullable: false),
                    Comments = table.Column<string>(maxLength: 3000, nullable: true),
                    Active = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrJobCandidateEducation", x => new { x.ID, x.JobCandidateID });
                    table.ForeignKey(
                        name: "FK_HrJobCandidateEducation_HrJobCandidate_JobCandidateID",
                        column: x => x.JobCandidateID,
                        principalTable: "HrJobCandidate",
                        principalColumn: "JobCandidateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HrJobCandidateExperience",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCandidateID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: true),
                    CorporateID = table.Column<int>(nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    DateStart = table.Column<DateTime>(nullable: true),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsCurrentJob = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(maxLength: 3000, nullable: true),
                    Comments = table.Column<string>(maxLength: 3000, nullable: true),
                    Salary = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    SalaryCycle = table.Column<string>(maxLength: 6, nullable: true),
                    Bonus = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    Commission = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    JobOrderID = table.Column<int>(nullable: true),
                    PlacementID = table.Column<int>(nullable: true),
                    TerminationReason = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrJobCandidateExperience", x => new { x.ID, x.JobCandidateID });
                    table.ForeignKey(
                        name: "FK_HrJobCandidateExperience_HrJobCandidate_JobCandidateID",
                        column: x => x.JobCandidateID,
                        principalTable: "HrJobCandidate",
                        principalColumn: "JobCandidateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HrJobCandidateCertificate_JobCandidateID",
                table: "HrJobCandidateCertificate",
                column: "JobCandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_HrJobCandidateEducation_JobCandidateID",
                table: "HrJobCandidateEducation",
                column: "JobCandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_HrJobCandidateExperience_JobCandidateID",
                table: "HrJobCandidateExperience",
                column: "JobCandidateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrJobCandidateCertificate");

            migrationBuilder.DropTable(
                name: "HrJobCandidateEducation");

            migrationBuilder.DropTable(
                name: "HrJobCandidateExperience");

            migrationBuilder.DropTable(
                name: "HrJobCandidate");

            migrationBuilder.DropColumn(
                name: "LinkedCorpContact",
                table: "HrCandidate");

            migrationBuilder.AddColumn<string>(
                name: "CandidateSource",
                table: "HrCandidate",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedClientContact",
                table: "HrCandidate",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HrCorporateCandidate",
                columns: table => new
                {
                    CorpCandidateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CandidateSource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    CorporateID = table.Column<int>(type: "int", nullable: false),
                    CurrCompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CurrCompanyURL = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CurrOccupation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAvailable = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateLastComment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateNextCall = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    Disability = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    EmploymentPreference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpectedSalary = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    ExpectedSalaryLow = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    ExperienceLevel = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    ExternalID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    HighestEduLevel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    IsEditable = table.Column<bool>(type: "bit", nullable: true),
                    IsExempt = table.Column<bool>(type: "bit", nullable: true),
                    IsMassMailOptOut = table.Column<bool>(type: "bit", nullable: true),
                    IsMessengerOptIn = table.Column<bool>(type: "bit", nullable: true),
                    IsSmsOptIn = table.Column<bool>(type: "bit", nullable: true),
                    IsWhatsappOptIn = table.Column<bool>(type: "bit", nullable: true),
                    JobIndustry = table.Column<short>(type: "smallint", nullable: true),
                    JobOrderID = table.Column<int>(type: "int", nullable: false),
                    JobSearchingMode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LinkedClientContact = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Nationality = table.Column<short>(type: "smallint", nullable: true),
                    OnboardingStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Placements = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PreferredContactModes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PreferredLocations = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PrimarySkills = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Privacy = table.Column<short>(type: "smallint", nullable: true),
                    SecondarySkills = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SkillSetDesc = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Specialties = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TimeZoneOffsetEST = table.Column<int>(type: "int", nullable: true),
                    TotalExperience = table.Column<int>(type: "int", nullable: true),
                    WorkPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrCorporateCandidate", x => x.CorpCandidateID);
                });
        }
    }
}
