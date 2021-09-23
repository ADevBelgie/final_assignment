using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace final_assignment.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingBagId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RememberLogin = table.Column<bool>(type: "bit", nullable: false),
                    ReturnUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.LoginId);
                    table.UniqueConstraint("AK_Logins_UserName", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Obsolete = table.Column<bool>(type: "bit", nullable: false),
                    AmountInStock = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityInPackage = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingBags",
                columns: table => new
                {
                    ShoppingBagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginId = table.Column<int>(type: "int", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingBags", x => x.ShoppingBagId);
                    table.ForeignKey(
                        name: "FK_ShoppingBags_Logins_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Logins",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingBagId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingItems_ShoppingBags_ShoppingBagId",
                        column: x => x.ShoppingBagId,
                        principalTable: "ShoppingBags",
                        principalColumn: "ShoppingBagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "LoginId", "EmailAddress", "Password", "RememberLogin", "ReturnUrl", "Role", "ShoppingBagId", "UserName" },
                values: new object[,]
                {
                    { 1, null, "admin", false, null, "admin", 0, "admin1" },
                    { 2, null, "arthur", false, null, "normal", 0, "arthur" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AmountInStock", "Category", "Color", "Description", "Name", "Obsolete", "Price", "product_type", "Size" },
                values: new object[,]
                {
                    { 18, 0, "Color", "green", "Aerodynamic", "Aero shirt", true, 20m, "nonfood", "50x50" },
                    { 17, 0, "Color", "orange", "underwater", "gps", false, 31m, "nonfood", "10x10" },
                    { 16, 10, "Color", "blue", "Mega fast", "Booster", false, 46m, "nonfood", "3x3" },
                    { 15, 100, "Color", "black", "Durable", "Bottle", false, 9m, "nonfood", "5x5" },
                    { 14, 8, "Color", "white", "Aerodynamic", "Aero pants", false, 20m, "nonfood", "3x3" },
                    { 13, 0, "Color", "green", "Aerodynamic", "Aero shirt", true, 20m, "nonfood", "50x50" },
                    { 12, 0, "Color", "orange", "underwater", "gps", false, 31m, "nonfood", "10x10" },
                    { 11, 10, "Color", "blue", "Mega fast", "Booster", false, 46m, "nonfood", "3x3" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AmountInStock", "Category", "Description", "Name", "Obsolete", "Price", "product_type", "QuantityInPackage" },
                values: new object[,]
                {
                    { 1, 10, "QuantityInPackage", "Jummy food", "Pizza", false, 50m, "food", 3 },
                    { 10, 150, "QuantityInPackage", "Chocolate food", "Choco", false, 19m, "food", 5 },
                    { 9, 8, "QuantityInPackage", "Fatty food", "Jelly", false, 19m, "food", 18 },
                    { 8, 0, "QuantityInPackage", "Dog food", "Dog Crunch", true, 19m, "food", 3 },
                    { 7, 0, "QuantityInPackage", "Bug food", "Flies", false, 32m, "food", 3 },
                    { 6, 10, "QuantityInPackage", "Jummy food", "Pizza", false, 50m, "food", 3 },
                    { 5, 150, "QuantityInPackage", "Chocolate food", "Choco", false, 19m, "food", 5 },
                    { 4, 8, "QuantityInPackage", "Fatty food", "Jelly", false, 19m, "food", 18 },
                    { 3, 0, "QuantityInPackage", "Dog food", "Dog Crunch", true, 19m, "food", 3 },
                    { 2, 0, "QuantityInPackage", "Bug food", "Flies", false, 32m, "food", 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AmountInStock", "Category", "Color", "Description", "Name", "Obsolete", "Price", "product_type", "Size" },
                values: new object[,]
                {
                    { 19, 8, "Color", "white", "Aerodynamic", "Aero pants", false, 20m, "nonfood", "3x3" },
                    { 20, 100, "Color", "black", "Durable", "Bottle", false, 9m, "nonfood", "5x5" }
                });

            migrationBuilder.InsertData(
                table: "ShoppingBags",
                columns: new[] { "ShoppingBagId", "LoginId", "TimeCreated" },
                values: new object[] { 1, 1, new DateTime(2021, 9, 23, 13, 38, 17, 494, DateTimeKind.Local).AddTicks(4322) });

            migrationBuilder.InsertData(
                table: "ShoppingBags",
                columns: new[] { "ShoppingBagId", "LoginId", "TimeCreated" },
                values: new object[] { 2, 2, new DateTime(2021, 9, 23, 13, 38, 17, 495, DateTimeKind.Local).AddTicks(2820) });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBags_LoginId",
                table: "ShoppingBags",
                column: "LoginId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItems_ProductId",
                table: "ShoppingItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItems_ShoppingBagId",
                table: "ShoppingItems",
                column: "ShoppingBagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingBags");

            migrationBuilder.DropTable(
                name: "Logins");
        }
    }
}
