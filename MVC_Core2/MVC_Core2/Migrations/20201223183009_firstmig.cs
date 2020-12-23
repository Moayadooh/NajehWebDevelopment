using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Core2.Migrations
{
    public partial class firstmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    DrinkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    IsDrinkOfWeek = table.Column<bool>(type: "bit", nullable: false),
                    feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.DrinkID);
                    table.ForeignKey(
                        name: "FK_Drinks_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Soft" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Hot" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "smoothie" });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "DrinkID", "CategoryID", "Description", "ImageUrl", "InStock", "IsDrinkOfWeek", "Name", "Price", "feedback" },
                values: new object[] { 1, 1, "karak trea description", "Images/karak.jpeg", true, true, "Kara", 12.949999999999999, null });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "DrinkID", "CategoryID", "Description", "ImageUrl", "InStock", "IsDrinkOfWeek", "Name", "Price", "feedback" },
                values: new object[] { 2, 1, "pepsi trea description", "Images/pepsi.jpg", true, true, "Pepsi", 12.949999999999999, null });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "DrinkID", "CategoryID", "Description", "ImageUrl", "InStock", "IsDrinkOfWeek", "Name", "Price", "feedback" },
                values: new object[] { 3, 1, "Tea Description", "Images/tea.png", true, true, "Tea Soluimani", 12.949999999999999, null });

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_CategoryID",
                table: "Drinks",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
