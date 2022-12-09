using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class ATS12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinExperienceLevel",
                table: "HrJobOrder");

            migrationBuilder.DropColumn(
                name: "SalaryUnit",
                table: "HrJobOrder");

            migrationBuilder.AlterColumn<int>(
                name: "JobSpecialty",
                table: "HrJobOrder",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JobIndustry",
                table: "HrJobOrder",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "EmploymentType",
                table: "HrJobOrder",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Country",
                table: "HrJobOrder",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<short>(
                name: "MinCareerLevel",
                table: "HrJobOrder",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "SalaryPayCycle",
                table: "HrJobOrder",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinCareerLevel",
                table: "HrJobOrder");

            migrationBuilder.DropColumn(
                name: "SalaryPayCycle",
                table: "HrJobOrder");

            migrationBuilder.AlterColumn<string>(
                name: "JobSpecialty",
                table: "HrJobOrder",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobIndustry",
                table: "HrJobOrder",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmploymentType",
                table: "HrJobOrder",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "HrJobOrder",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(short));

            migrationBuilder.AddColumn<short>(
                name: "MinExperienceLevel",
                table: "HrJobOrder",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalaryUnit",
                table: "HrJobOrder",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);
        }
    }
}
