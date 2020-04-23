using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DDWork.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "carriage_should_count_price",
                table: "transportation",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "car",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExpenditrueViewModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    sharehloder_name = table.Column<string>(nullable: true),
                    material_count_price = table.Column<double>(nullable: false),
                    carriage_count_price = table.Column<double>(nullable: false),
                    car_no = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenditrueViewModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GainLossViewModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gain_or_loss = table.Column<string>(nullable: true),
                    item = table.Column<string>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GainLossViewModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ShareholderViewModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    shareholder_name = table.Column<string>(nullable: true),
                    out_count_price = table.Column<double>(nullable: false),
                    average_count_price = table.Column<double>(nullable: false),
                    difference_count_price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareholderViewModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TransportationViewModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    material_name = table.Column<string>(nullable: true),
                    supply_name = table.Column<string>(nullable: true),
                    car_no = table.Column<string>(nullable: true),
                    start_date = table.Column<string>(nullable: true),
                    end_date = table.Column<string>(nullable: true),
                    customer_name = table.Column<string>(nullable: true),
                    material_weight = table.Column<double>(nullable: false),
                    carriage_weight = table.Column<double>(nullable: false),
                    material_unit_price = table.Column<double>(nullable: false),
                    carriage_unit_price = table.Column<double>(nullable: false),
                    material_count_price = table.Column<double>(nullable: false),
                    carriage_count_price = table.Column<double>(nullable: false),
                    shareholder_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationViewModel", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenditrueViewModel");

            migrationBuilder.DropTable(
                name: "GainLossViewModel");

            migrationBuilder.DropTable(
                name: "ShareholderViewModel");

            migrationBuilder.DropTable(
                name: "TransportationViewModel");

            migrationBuilder.DropColumn(
                name: "carriage_should_count_price",
                table: "transportation");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "car");
        }
    }
}
