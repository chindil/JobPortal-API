using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class Nov233 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "CorporateDTO");

            //migrationBuilder.DropTable(
            //    name: "HrCandidatePublicDTO");

            //migrationBuilder.DropTable(
            //    name: "HrJobCandidateListDTO");

            //migrationBuilder.DropTable(
            //    name: "HrJobOrderPreview");

            //migrationBuilder.DropTable(
            //    name: "HrJobSummaryDTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HrAtsTeam",
                table: "HrAtsTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HrAtsMailTemplate",
                table: "HrAtsMailTemplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HrAtsDepartment",
                table: "HrAtsDepartment");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "HrAtsTeam",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HrAtsMailTemplate",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HrAtsDepartment",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HrAtsTeam",
                table: "HrAtsTeam",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HrAtsMailTemplate",
                table: "HrAtsMailTemplate",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HrAtsDepartment",
                table: "HrAtsDepartment",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_HrAtsTeam_CorporateID_Email",
                table: "HrAtsTeam",
                columns: new[] { "CorporateID", "Email" },
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HrAtsMailTemplate_CorporateID_Name",
                table: "HrAtsMailTemplate",
                columns: new[] { "CorporateID", "Name" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HrAtsDepartment_CorporateID_Name",
                table: "HrAtsDepartment",
                columns: new[] { "CorporateID", "Name" },
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HrAtsTeam",
                table: "HrAtsTeam");

            migrationBuilder.DropIndex(
                name: "IX_HrAtsTeam_CorporateID_Email",
                table: "HrAtsTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HrAtsMailTemplate",
                table: "HrAtsMailTemplate");

            migrationBuilder.DropIndex(
                name: "IX_HrAtsMailTemplate_CorporateID_Name",
                table: "HrAtsMailTemplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HrAtsDepartment",
                table: "HrAtsDepartment");

            migrationBuilder.DropIndex(
                name: "IX_HrAtsDepartment_CorporateID_Name",
                table: "HrAtsDepartment");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "HrAtsTeam",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HrAtsMailTemplate",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HrAtsDepartment",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HrAtsTeam",
                table: "HrAtsTeam",
                columns: new[] { "CorporateID", "Email" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_HrAtsMailTemplate",
                table: "HrAtsMailTemplate",
                columns: new[] { "CorporateID", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_HrAtsDepartment",
                table: "HrAtsDepartment",
                columns: new[] { "CorporateID", "Name" });

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
                name: "HrCandidatePublicDTO",
                columns: table => new
                {
                    Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    CandidateSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAvailable = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateLastComment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateNextCall = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedJobs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedSalary = table.Column<decimal>(type: "NUMERIC(9,6)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobOrderID = table.Column<int>(type: "int", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<short>(type: "smallint", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SummaryDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeZoneOffsetEST = table.Column<int>(type: "int", nullable: true),
                    TotalExperience = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPhone = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
