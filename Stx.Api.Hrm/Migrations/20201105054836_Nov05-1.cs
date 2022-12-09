using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class Nov051 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "CountryID",
                table: "HrJobCandidate",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "CountryID",
                table: "HrCandidate",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HrAtsDepartment",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "HrAtsDepartment",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "HrJobCandidate");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "HrCandidate");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "HrAtsDepartment");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HrAtsDepartment",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
