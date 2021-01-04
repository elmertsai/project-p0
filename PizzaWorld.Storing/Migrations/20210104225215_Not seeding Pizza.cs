using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class NotseedingPizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APizzaModelEntityID = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedStoreEntityID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Users_Stores_SelectedStoreEntityID",
                        column: x => x.SelectedStoreEntityID,
                        principalTable: "Stores",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEntityID = table.Column<long>(type: "bigint", nullable: true),
                    StoreEntityID = table.Column<long>(type: "bigint", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    Ordertime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Order_Stores_StoreEntityID",
                        column: x => x.StoreEntityID,
                        principalTable: "Stores",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Users_UserEntityID",
                        column: x => x.UserEntityID,
                        principalTable: "Users",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    crustEntityID = table.Column<long>(type: "bigint", nullable: true),
                    sizeEntityID = table.Column<long>(type: "bigint", nullable: true),
                    OrderEntityID = table.Column<long>(type: "bigint", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Pizzas_Crusts_crustEntityID",
                        column: x => x.crustEntityID,
                        principalTable: "Crusts",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Order_OrderEntityID",
                        column: x => x.OrderEntityID,
                        principalTable: "Order",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sizes_sizeEntityID",
                        column: x => x.sizeEntityID,
                        principalTable: "Sizes",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "APizzaModelTopping",
                columns: table => new
                {
                    PizzasEntityID = table.Column<long>(type: "bigint", nullable: false),
                    toppingsEntityID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APizzaModelTopping", x => new { x.PizzasEntityID, x.toppingsEntityID });
                    table.ForeignKey(
                        name: "FK_APizzaModelTopping_Pizzas_PizzasEntityID",
                        column: x => x.PizzasEntityID,
                        principalTable: "Pizzas",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_APizzaModelTopping_Toppings_toppingsEntityID",
                        column: x => x.toppingsEntityID,
                        principalTable: "Toppings",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "EntityID", "name", "price" },
                values: new object[,]
                {
                    { 1L, "Thin", 0.0 },
                    { 2L, "Hand Tossed", 0.0 },
                    { 3L, "Cheese-Stuffed", 2.0 }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "EntityID", "name", "price" },
                values: new object[,]
                {
                    { 1L, "Small", 0.0 },
                    { 2L, "Medium", 3.0 },
                    { 3L, "Large", 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityID", "Address", "Name" },
                values: new object[,]
                {
                    { 1L, "Store 1 Address", "One" },
                    { 2L, "Store 2 Address", "Two" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "EntityID", "APizzaModelEntityID", "name", "price" },
                values: new object[,]
                {
                    { 1L, 0L, "Cheese", 0.0 },
                    { 2L, 0L, "Premium Chicken", 2.0 },
                    { 3L, 0L, "Pulled Pork", 2.0 },
                    { 4L, 0L, "Mushroom", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "EntityID", "Name", "SelectedStoreEntityID" },
                values: new object[,]
                {
                    { 1L, "Elmer", null },
                    { 2L, "Elmer2", null },
                    { 3L, "user3", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_APizzaModelTopping_toppingsEntityID",
                table: "APizzaModelTopping",
                column: "toppingsEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreEntityID",
                table: "Order",
                column: "StoreEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserEntityID",
                table: "Order",
                column: "UserEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_crustEntityID",
                table: "Pizzas",
                column: "crustEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderEntityID",
                table: "Pizzas",
                column: "OrderEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_sizeEntityID",
                table: "Pizzas",
                column: "sizeEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SelectedStoreEntityID",
                table: "Users",
                column: "SelectedStoreEntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APizzaModelTopping");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
