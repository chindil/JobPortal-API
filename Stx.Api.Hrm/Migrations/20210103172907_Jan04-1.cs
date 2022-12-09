using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class Jan041 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "CorporateDTO");

            //migrationBuilder.DropTable(
            //    name: "CorporatePublicDTO");

            //migrationBuilder.DropTable(
            //    name: "HrJobCandidateListDTO");

            //migrationBuilder.DropTable(
            //    name: "HrJobOrderPreview");

            //migrationBuilder.DropTable(
            //    name: "HrJobOrderSearch");

            //migrationBuilder.DropTable(
            //    name: "HrJobSummaryDTO");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedUsers",
                table: "HrJobOrder",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AutoRejectEmailTemplate",
                table: "HrJobOrder",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoRejectEmailTemplate",
                table: "HrJobOrder");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedUsers",
                table: "HrJobOrder",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CorporateDTO",
                columns: table => new
                {
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplyByEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplyByMobileNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateID = table.Column<int>(type: "int", nullable: false),
                    CorporateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateOperationHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateLastPublished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileAttachments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsShowSalary = table.Column<bool>(type: "bit", nullable: true),
                    JobCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobHoursPerWeek = table.Column<decimal>(type: "NUMERIC(6,2)", nullable: true),
                    JobIndustry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobOrderID = table.Column<int>(type: "int", nullable: false),
                    JobPostPrivacy = table.Column<int>(type: "int", nullable: true),
                    JobSpecialty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinEducationLevel = table.Column<short>(type: "smallint", nullable: true),
                    MinExperienceLevel = table.Column<short>(type: "smallint", nullable: true),
                    MinYearsExpRequired = table.Column<decimal>(type: "NUMERIC(6,2)", nullable: true),
                    NumOfAvilJobs = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrevSendoutID = table.Column<int>(type: "int", nullable: true),
                    Privacy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportToClientContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportToName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    SalaryCurrCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryTo = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    SalaryUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelRequirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CorporatePublicDTO",
                columns: table => new
                {
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialRegInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommercialRegNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyLawyers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateID = table.Column<int>(type: "int", nullable: false),
                    CorporateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID = table.Column<short>(type: "smallint", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImportRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<short>(type: "smallint", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Privacy = table.Column<short>(type: "smallint", nullable: true),
                    RefObject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "HrJobCandidateListDTO",
                columns: table => new
                {
                    CandidateID = table.Column<int>(type: "int", nullable: true),
                    CandidateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobCandidateID = table.Column<int>(type: "int", nullable: false),
                    JobOrderID = table.Column<int>(type: "int", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "HrJobOrderPreview",
                columns: table => new
                {
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplyByEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplyByMobileNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateID = table.Column<int>(type: "int", nullable: false),
                    CorporateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateOperationHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<short>(type: "smallint", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateLastPublished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploymentType = table.Column<short>(type: "smallint", nullable: false),
                    FileAttachments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsShowSalary = table.Column<bool>(type: "bit", nullable: true),
                    JobCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobHoursPerWeek = table.Column<decimal>(type: "NUMERIC(6,2)", nullable: true),
                    JobIndustry = table.Column<int>(type: "int", nullable: true),
                    JobOrderID = table.Column<int>(type: "int", nullable: false),
                    JobPostPrivacy = table.Column<short>(type: "smallint", nullable: true),
                    JobSpecialty = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinCareerLevel = table.Column<short>(type: "smallint", nullable: true),
                    MinEducationLevel = table.Column<short>(type: "smallint", nullable: true),
                    MinYearsExpRequired = table.Column<decimal>(type: "NUMERIC(6,2)", nullable: true),
                    NumOfAvilJobs = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrevSendoutID = table.Column<int>(type: "int", nullable: true),
                    Privacy = table.Column<short>(type: "smallint", nullable: false),
                    ReportToClientContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportToName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    SalaryCurrCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryPayCycle = table.Column<short>(type: "smallint", nullable: false),
                    SalaryTo = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelRequirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "HrJobOrderSearch",
                columns: table => new
                {
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplyByEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplyByMobileNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateCountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateID = table.Column<int>(type: "int", nullable: true),
                    CorporateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileAttachments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsShowSalary = table.Column<bool>(type: "bit", nullable: true),
                    JobCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobHoursPerWeek = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    JobIndustry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobOrderID = table.Column<int>(type: "int", nullable: false),
                    JobSpecialty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinCareerLevel = table.Column<short>(type: "smallint", nullable: true),
                    MinEducationLevel = table.Column<short>(type: "smallint", nullable: true),
                    MinYearsExpRequired = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    NumOfAvilJobs = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Privacy = table.Column<short>(type: "smallint", nullable: true),
                    Requirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumeSubmitCount = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    SalaryCurrCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryPayCycle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryTo = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelRequirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "HrJobSummaryDTO",
                columns: table => new
                {
                    AppliedCount = table.Column<int>(type: "int", nullable: true),
                    ApplyByEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplyByMobileNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorporateID = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<short>(type: "smallint", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateLastApplied = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploymentType = table.Column<short>(type: "smallint", nullable: true),
                    HiredCount = table.Column<int>(type: "int", nullable: true),
                    InterviewCount = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    JobCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobIndustry = table.Column<int>(type: "int", nullable: true),
                    JobIndustryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobOrderID = table.Column<int>(type: "int", nullable: false),
                    JobSpecialty = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumOfAvilJobs = table.Column<int>(type: "int", nullable: true),
                    OfferCount = table.Column<int>(type: "int", nullable: true),
                    PhoneScreenCount = table.Column<int>(type: "int", nullable: true),
                    Requirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourcedCount = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelRequirements = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }
    }
}
