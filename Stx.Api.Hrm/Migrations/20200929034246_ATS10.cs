using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class ATS10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_City",
            //    table: "City");

            //migrationBuilder.DropColumn(
            //    name: "CityCD",
            //    table: "City");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "HrJobCategory",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "HrJobCategory",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "City",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "CityID");

            migrationBuilder.CreateTable(
                name: "HrJobIndustry",
                columns: table => new
                {
                    ID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: true),
                    Active = table.Column<bool>(nullable: true, defaultValue: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrJobIndustry", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HrJobSkill",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    RecID = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: true, defaultValue: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrJobSkill", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "HrJobSpecialty",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCategoryID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: true),
                    Active = table.Column<bool>(nullable: true, defaultValue: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HrJobSpecialty", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HrJobIndustry");

            migrationBuilder.DropTable(
                name: "HrJobSkill");

            migrationBuilder.DropTable(
                name: "HrJobSpecialty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "City");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "HrJobCategory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "HrJobCategory",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "CityCD",
                table: "City",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "CityCD");
        }
    }
}
