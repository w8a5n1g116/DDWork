using Microsoft.EntityFrameworkCore.Migrations;

namespace DDWork.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "car_name",
                table: "TransportationViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "car_phone",
                table: "TransportationViewModel",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "carriage_should_count_price",
                table: "TransportationViewModel",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "pay_time",
                table: "TransportationViewModel",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "service_charge",
                table: "TransportationViewModel",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "pay_time",
                table: "transportation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "car_name",
                table: "TransportationViewModel");

            migrationBuilder.DropColumn(
                name: "car_phone",
                table: "TransportationViewModel");

            migrationBuilder.DropColumn(
                name: "carriage_should_count_price",
                table: "TransportationViewModel");

            migrationBuilder.DropColumn(
                name: "pay_time",
                table: "TransportationViewModel");

            migrationBuilder.DropColumn(
                name: "service_charge",
                table: "TransportationViewModel");

            migrationBuilder.DropColumn(
                name: "pay_time",
                table: "transportation");
        }
    }
}
