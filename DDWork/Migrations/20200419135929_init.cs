using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DDWork.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    car_no = table.Column<string>(nullable: true),
                    car_load = table.Column<string>(nullable: true),
                    bank_no = table.Column<string>(nullable: true),
                    bank_name = table.Column<string>(nullable: true),
                    create_time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    create_time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "material",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    unit = table.Column<string>(nullable: true),
                    create_time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_material", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shareholder",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    create_time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shareholder", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "supply",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    create_time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supply", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    privileges = table.Column<string>(nullable: true),
                    create_time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "income",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    count_price = table.Column<double>(nullable: false),
                    create_time = table.Column<string>(nullable: true),
                    customerid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_income", x => x.id);
                    table.ForeignKey(
                        name: "FK_income_customer_customerid",
                        column: x => x.customerid,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contract",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    weight = table.Column<double>(nullable: false),
                    contract_price = table.Column<double>(nullable: false),
                    delivery_date = table.Column<string>(nullable: true),
                    customerid = table.Column<int>(nullable: true),
                    materialid = table.Column<int>(nullable: true),
                    create_time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contract", x => x.id);
                    table.ForeignKey(
                        name: "FK_contract_customer_customerid",
                        column: x => x.customerid,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contract_material_materialid",
                        column: x => x.materialid,
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "material_unit_price",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    price = table.Column<double>(nullable: false),
                    create_time = table.Column<string>(nullable: true),
                    materialid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_material_unit_price", x => x.id);
                    table.ForeignKey(
                        name: "FK_material_unit_price_material_materialid",
                        column: x => x.materialid,
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transportation",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    material_weight = table.Column<double>(nullable: false),
                    carriage_weight = table.Column<double>(nullable: false),
                    material_unit_price = table.Column<double>(nullable: false),
                    carriage_unit_price = table.Column<double>(nullable: false),
                    material_count_price = table.Column<double>(nullable: false),
                    carriage_count_price = table.Column<double>(nullable: false),
                    start_date = table.Column<double>(nullable: false),
                    end_date = table.Column<double>(nullable: false),
                    create_time = table.Column<string>(nullable: true),
                    customerid = table.Column<int>(nullable: true),
                    shareholderid = table.Column<int>(nullable: true),
                    carid = table.Column<int>(nullable: true),
                    supplyid = table.Column<int>(nullable: true),
                    materialid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transportation", x => x.id);
                    table.ForeignKey(
                        name: "FK_transportation_car_carid",
                        column: x => x.carid,
                        principalTable: "car",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transportation_customer_customerid",
                        column: x => x.customerid,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transportation_material_materialid",
                        column: x => x.materialid,
                        principalTable: "material",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transportation_shareholder_shareholderid",
                        column: x => x.shareholderid,
                        principalTable: "shareholder",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transportation_supply_supplyid",
                        column: x => x.supplyid,
                        principalTable: "supply",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "expenditure",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    material_count_price = table.Column<double>(nullable: false),
                    carriage_count_price = table.Column<double>(nullable: false),
                    create_time = table.Column<string>(nullable: true),
                    shareholderid = table.Column<int>(nullable: true),
                    transportationid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenditure", x => x.id);
                    table.ForeignKey(
                        name: "FK_expenditure_shareholder_shareholderid",
                        column: x => x.shareholderid,
                        principalTable: "shareholder",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_expenditure_transportation_transportationid",
                        column: x => x.transportationid,
                        principalTable: "transportation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contract_customerid",
                table: "contract",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_contract_materialid",
                table: "contract",
                column: "materialid");

            migrationBuilder.CreateIndex(
                name: "IX_expenditure_shareholderid",
                table: "expenditure",
                column: "shareholderid");

            migrationBuilder.CreateIndex(
                name: "IX_expenditure_transportationid",
                table: "expenditure",
                column: "transportationid");

            migrationBuilder.CreateIndex(
                name: "IX_income_customerid",
                table: "income",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_material_unit_price_materialid",
                table: "material_unit_price",
                column: "materialid");

            migrationBuilder.CreateIndex(
                name: "IX_transportation_carid",
                table: "transportation",
                column: "carid");

            migrationBuilder.CreateIndex(
                name: "IX_transportation_customerid",
                table: "transportation",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_transportation_materialid",
                table: "transportation",
                column: "materialid");

            migrationBuilder.CreateIndex(
                name: "IX_transportation_shareholderid",
                table: "transportation",
                column: "shareholderid");

            migrationBuilder.CreateIndex(
                name: "IX_transportation_supplyid",
                table: "transportation",
                column: "supplyid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contract");

            migrationBuilder.DropTable(
                name: "expenditure");

            migrationBuilder.DropTable(
                name: "income");

            migrationBuilder.DropTable(
                name: "material_unit_price");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "transportation");

            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "material");

            migrationBuilder.DropTable(
                name: "shareholder");

            migrationBuilder.DropTable(
                name: "supply");
        }
    }
}
