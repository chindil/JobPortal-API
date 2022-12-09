using Microsoft.EntityFrameworkCore.Migrations;

namespace Stx.Api.Hrm.Migrations
{
    public partial class MatterUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionID",
                table: "IPMatter");

            migrationBuilder.RenameColumn(
                name: "DocStatus",
                table: "IPMatter",
                newName: "Status");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "IPMatter",
                type: "NUMERIC(19,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(19,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MatterValue",
                table: "IPMatter",
                type: "NUMERIC(19,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(19,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DynmPaidAmt",
                table: "IPMatter",
                type: "NUMERIC(19,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(19,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "DynmBillableAmt",
                table: "IPMatter",
                type: "NUMERIC(19,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(19,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ContngncyRatePct",
                table: "IPMatter",
                type: "NUMERIC(6,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(6,2)");

            migrationBuilder.AlterColumn<short>(
                name: "CompanyID",
                table: "IPMatter",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "IPMatter",
                newName: "DocStatus");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "IPMatter",
                type: "NUMERIC(19,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(19,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MatterValue",
                table: "IPMatter",
                type: "NUMERIC(19,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(19,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DynmPaidAmt",
                table: "IPMatter",
                type: "NUMERIC(19,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(19,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DynmBillableAmt",
                table: "IPMatter",
                type: "NUMERIC(19,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(19,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ContngncyRatePct",
                table: "IPMatter",
                type: "NUMERIC(6,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(6,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "CompanyID",
                table: "IPMatter",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionID",
                table: "IPMatter",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
