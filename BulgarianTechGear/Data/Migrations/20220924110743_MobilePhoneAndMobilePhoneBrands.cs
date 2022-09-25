using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulgarianTechGear.Data.Migrations
{
    public partial class MobilePhoneAndMobilePhoneBrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MobilePhoneBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobilePhoneBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MobilePhones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PixelsFrontCamera = table.Column<int>(type: "int", nullable: false),
                    PixelsBackCamera = table.Column<int>(type: "int", nullable: false),
                    Memory = table.Column<int>(type: "int", nullable: false),
                    DisplaySizeInch = table.Column<double>(type: "float", nullable: false),
                    BatteryCapacity = table.Column<double>(type: "float", nullable: false),
                    DisplayType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ram = table.Column<int>(type: "int", nullable: false),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhoneBrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobilePhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobilePhones_MobilePhoneBrands_MobilePhoneBrandId",
                        column: x => x.MobilePhoneBrandId,
                        principalTable: "MobilePhoneBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobilePhones_MobilePhoneBrandId",
                table: "MobilePhones",
                column: "MobilePhoneBrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobilePhones");

            migrationBuilder.DropTable(
                name: "MobilePhoneBrands");
        }
    }
}
