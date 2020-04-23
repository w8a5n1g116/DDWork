using Microsoft.EntityFrameworkCore.Migrations;

namespace DDWork.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "debt_price",
                table: "contract",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "real_receive_price",
                table: "contract",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "should_receive_price",
                table: "contract",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "unit_price",
                table: "contract",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "unprint_price",
                table: "contract",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "unprint_weight",
                table: "contract",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "debt_price",
                table: "contract");

            migrationBuilder.DropColumn(
                name: "real_receive_price",
                table: "contract");

            migrationBuilder.DropColumn(
                name: "should_receive_price",
                table: "contract");

            migrationBuilder.DropColumn(
                name: "unit_price",
                table: "contract");

            migrationBuilder.DropColumn(
                name: "unprint_price",
                table: "contract");

            migrationBuilder.DropColumn(
                name: "unprint_weight",
                table: "contract");
        }
    }
}
