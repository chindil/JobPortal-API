using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class ATS14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "HrJobOrder");

            migrationBuilder.CreateTable(
                name: "HrCorporateCandidate",
                columns: table => new
                {
                    CorpCandidateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorporateID = table.Column<int>(nullable: false),
                    JobOrderID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Gender = table.Column<string>(maxLength: 1, nullable: true),
                    Nationality = table.Column<short>(nullable: true),
                    Mobile = table.Column<string>(maxLength: 20, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    WorkPhone = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 150, nullable: true),
                    Fax = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    Address2 = table.Column<string>(maxLength: 200, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
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
                    CandidateSource = table.Column<string>(maxLength: 50, nullable: true),
                    Disability = table.Column<string>(maxLength: 20, nullable: true),
                    LinkedClientContact = table.Column<string>(maxLength: 30, nullable: true),
                    Owner = table.Column<string>(maxLength: 50, nullable: true),
                    OnboardingStatus = table.Column<string>(maxLength: 20, nullable: true),
                    Placements = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrCorporateCandidate", x => x.CorpCandidateID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrCorporateCandidate");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "HrJobOrder",
                type: "bit",
                nullable: true,
                defaultValue: true);
        }
    }
}
