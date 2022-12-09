using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class ATS8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "HrCandidate");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Corporate");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "HrCandidate",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrCD",
                table: "Corporate",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Corporate",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HrCandidate_UserName",
                table: "HrCandidate",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Corporate_UserName",
                table: "Corporate",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HrCandidate_UserName",
                table: "HrCandidate");

            migrationBuilder.DropIndex(
                name: "IX_Corporate_UserName",
                table: "Corporate");

            migrationBuilder.DropColumn(
                name: "CurrCD",
                table: "Corporate");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Corporate");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "HrCandidate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "HrCandidate",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Corporate",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true);
        }
    }
}
