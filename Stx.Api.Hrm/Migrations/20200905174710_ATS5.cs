using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class ATS5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Nationality",
                table: "HrCandidate",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "Nationality",
                table: "Corporate",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<short>(
                name: "CountryID",
                table: "Corporate",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.CreateTable(
                name: "HrJobOrder",
                columns: table => new
                {
                    JobOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCode = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    Location = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 3000, nullable: true),
                    Requirements = table.Column<string>(maxLength: 3000, nullable: true),
                    Benefits = table.Column<string>(maxLength: 3000, nullable: true),
                    Salary = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    SalaryTo = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    SalaryCurrCD = table.Column<string>(maxLength: 3, nullable: true),
                    SalaryUnit = table.Column<string>(maxLength: 1, nullable: true),
                    IsShowSalary = table.Column<bool>(nullable: false),
                    EmploymentType = table.Column<string>(maxLength: 15, nullable: true),
                    JobIndustry = table.Column<string>(maxLength: 100, nullable: true),
                    JobSpecialty = table.Column<string>(maxLength: 100, nullable: true),
                    JobHoursPerWeek = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true),
                    NumOfAvilJobs = table.Column<int>(nullable: false),
                    FileAttachments = table.Column<string>(maxLength: 100, nullable: true),
                    MinYearsExpRequired = table.Column<decimal>(type: "NUMERIC(6,2)", nullable: true),
                    MinExperienceLevel = table.Column<short>(nullable: true),
                    MinEducationLevel = table.Column<short>(nullable: true),
                    Comments = table.Column<string>(maxLength: 100, nullable: true),
                    TravelRequirements = table.Column<string>(maxLength: 200, nullable: true),
                    PostingJobBy = table.Column<string>(maxLength: 6, nullable: true),
                    CorporateContact = table.Column<string>(maxLength: 30, nullable: true),
                    CorporateID = table.Column<int>(nullable: true),
                    CorporateAddress = table.Column<string>(maxLength: 500, nullable: true),
                    CorporateOperationHours = table.Column<string>(maxLength: 50, nullable: true),
                    JobPostPrivacy = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: true, defaultValue: true),
                    IsInterviewRequired = table.Column<bool>(nullable: true),
                    IsJobcastPublished = table.Column<bool>(nullable: true),
                    JobOrderIntegrations = table.Column<string>(maxLength: 50, nullable: true),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateClosed = table.Column<DateTime>(nullable: true),
                    DateLastPublished = table.Column<DateTime>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateLastModified = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    ReasonClosed = table.Column<string>(maxLength: 50, nullable: true),
                    JobPostSource = table.Column<string>(maxLength: 100, nullable: true),
                    ReportToName = table.Column<string>(maxLength: 100, nullable: true),
                    ReportToClientContact = table.Column<string>(maxLength: 100, nullable: true),
                    AssignedUsers = table.Column<string>(maxLength: 200, nullable: true),
                    ExternalID = table.Column<string>(maxLength: 100, nullable: true),
                    IsBillable = table.Column<bool>(nullable: false),
                    BillingProfile = table.Column<string>(maxLength: 100, nullable: true),
                    BillingRate = table.Column<decimal>(type: "NUMERIC(19,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrJobOrder", x => x.JobOrderID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrJobOrder");

            migrationBuilder.AlterColumn<short>(
                name: "Nationality",
                table: "HrCandidate",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Nationality",
                table: "Corporate",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "CountryID",
                table: "Corporate",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(short),
                oldNullable: true);
        }
    }
}
