using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class ATS11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "HrJobIndustry",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "ID",
                table: "HrJobIndustry",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
