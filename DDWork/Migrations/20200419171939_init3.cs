using Microsoft.EntityFrameworkCore.Migrations;

namespace DDWork.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "start_date",
                table: "transportation",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<string>(
                name: "carriage_count_price",
                table: "transportation",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddColumn<double>(
                name: "fine",
                table: "contract",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "print_price",
                table: "contract",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "print_weight",
                table: "contract",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fine",
                table: "contract");

            migrationBuilder.DropColumn(
                name: "print_price",
                table: "contract");

            migrationBuilder.DropColumn(
                name: "print_weight",
                table: "contract");

            migrationBuilder.AlterColumn<double>(
                name: "start_date",
                table: "transportation",
                type: "double",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "carriage_count_price",
                table: "transportation",
                type: "double",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
