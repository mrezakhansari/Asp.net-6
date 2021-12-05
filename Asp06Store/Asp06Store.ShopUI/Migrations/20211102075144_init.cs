using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp06Store.ShopUI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Mobile", "Fingerprint (side-mounted), unspecified sensors", "Xiaomi Redmi Note 11", 30000000 },
                    { 2, "Mobile", "Face ID, accelerometer, gyro, proximity, compass, barometer", "Apple iPhone 13 mini", 50000000 },
                    { 3, "Laptop", "Fingerprint", "Asus", 300000000 },
                    { 4, "Laptop", "Face ID", "Dell", 500000000 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
