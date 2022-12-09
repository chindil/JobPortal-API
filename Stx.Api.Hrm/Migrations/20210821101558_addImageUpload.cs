using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class addImageUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImgKey",
                table: "HrJobCandidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileThumbImgKey",
                table: "HrJobCandidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImgKey",
                table: "HrCandidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileThumbImgKey",
                table: "HrCandidate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoImgKey",
                table: "Corporate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoThumbImgKey",
                table: "Corporate",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImgKey",
                table: "HrJobCandidate");

            migrationBuilder.DropColumn(
                name: "ProfileThumbImgKey",
                table: "HrJobCandidate");

            migrationBuilder.DropColumn(
                name: "ProfileImgKey",
                table: "HrCandidate");

            migrationBuilder.DropColumn(
                name: "ProfileThumbImgKey",
                table: "HrCandidate");

            migrationBuilder.DropColumn(
                name: "LogoImgKey",
                table: "Corporate");

            migrationBuilder.DropColumn(
                name: "LogoThumbImgKey",
                table: "Corporate");
        }
    }
}
