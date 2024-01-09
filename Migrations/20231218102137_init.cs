using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PizzaHut.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Speicality = table.Column<string>(type: "TEXT", nullable: true),
                    Crust = table.Column<string>(type: "TEXT", nullable: true),
                    Images = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Pizza_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Qty = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_ID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_UserID",
                        column: x => x.UserID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Pizza_Pizza_ID",
                        column: x => x.Pizza_ID,
                        principalTable: "Pizza",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Order_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    ToppingsID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_Order_ID",
                        column: x => x.Order_ID,
                        principalTable: "Orders",
                        principalColumn: "Order_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Toppings_ToppingsID",
                        column: x => x.ToppingsID,
                        principalTable: "Toppings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Address", "Name", "Password", "Phone", "UserID" },
                values: new object[,]
                {
                    { 101, "#Neyveli", "chandru", "chandru2598", "9876543213", "chandru@gmail.com" },
                    { 102, "#demo", "demo", "demo", "9876543214", "Demo@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "ID", "Crust", "Description", "Images", "Name", "Price", "Speicality" },
                values: new object[,]
                {
                    { 1001, "Fresh Pan Pizza", "Peppy Paneer Cheese Burst Topped with Extra Cheese", "/images/pizza-1.jpg", "Veg Loaded", 199.0, "with Pepse" },
                    { 1002, "Fresh Pan Pizza", "Peppy Paneer Cheese Burst Topped with Extra Cheese", "/images/pizza-2.jpg", "Peppy Paneer Pizza", 299.0, "with extra toppings" },
                    { 1003, "Fresh Pan Pizza", "Mashroon Topped", "/images/pizza-3.jpg", "Peper Chicken", 199.0, "with Pepse" },
                    { 1004, "Fresh Pan Pizza", "Peppy Paneer Cheese Burst Topped with Extra Cheese", "/images/pizza-4.jpg", "Non Veg Loaded", 299.0, "with Pepse" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ID", "Name", "Price" },
                values: new object[,]
                {
                    { 201, "Tomato", 99.0 },
                    { 202, "Cheese", 89.0 },
                    { 203, "Onion", 100.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_Order_ID",
                table: "OrderDetails",
                column: "Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ToppingsID",
                table: "OrderDetails",
                column: "ToppingsID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Pizza_ID",
                table: "Orders",
                column: "Pizza_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Pizza");
        }
    }
}
