using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityID",
                keyValue: 637447773049015173L);

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityID",
                keyValue: 637447773049015881L);

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityID",
                keyValue: 637447773049015897L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "EntityID",
                keyValue: 637447773049016538L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "EntityID",
                keyValue: 637447773049016570L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "EntityID",
                keyValue: 637447773049016580L);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "EntityID",
                keyValue: 637447773048974487L);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "EntityID",
                keyValue: 637447773049007237L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 637447773049017362L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 637447773049017888L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 637447773049017904L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 637447773049017914L);

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "EntityID", "name", "price" },
                values: new object[,]
                {
                    { 637452710179906803L, "Thin", 0.0 },
                    { 637452710179907944L, "Hand Tossed", 0.0 },
                    { 637452710179907960L, "Cheese-Stuffed", 2.0 }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "EntityID", "name", "price" },
                values: new object[,]
                {
                    { 637452710179908899L, "Small", 0.0 },
                    { 637452710179908930L, "Medium", 3.0 },
                    { 637452710179908941L, "Large", 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityID", "Address", "Name" },
                values: new object[,]
                {
                    { 637452710179865002L, "Store 1 Address", "One" },
                    { 637452710179898176L, "Store 2 Address", "Two" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "EntityID", "APizzaModelEntityID", "name", "price" },
                values: new object[,]
                {
                    { 637452710179909666L, null, "Cheese", 0.0 },
                    { 637452710179910172L, null, "Premium Chicken", 2.0 },
                    { 637452710179910188L, null, "Pulled Pork", 2.0 },
                    { 637452710179910198L, null, "Mushroom", 0.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityID",
                keyValue: 637452710179906803L);

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityID",
                keyValue: 637452710179907944L);

            migrationBuilder.DeleteData(
                table: "Crusts",
                keyColumn: "EntityID",
                keyValue: 637452710179907960L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "EntityID",
                keyValue: 637452710179908899L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "EntityID",
                keyValue: 637452710179908930L);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "EntityID",
                keyValue: 637452710179908941L);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "EntityID",
                keyValue: 637452710179865002L);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "EntityID",
                keyValue: 637452710179898176L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 637452710179909666L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 637452710179910172L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 637452710179910188L);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "EntityID",
                keyValue: 637452710179910198L);

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "EntityID", "name", "price" },
                values: new object[,]
                {
                    { 637447773049015173L, "Thin", 0.0 },
                    { 637447773049015881L, "Hand Tossed", 0.0 },
                    { 637447773049015897L, "Cheese-Stuffed", 2.0 }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "EntityID", "name", "price" },
                values: new object[,]
                {
                    { 637447773049016538L, "Small", 0.0 },
                    { 637447773049016570L, "Medium", 3.0 },
                    { 637447773049016580L, "Large", 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityID", "Address", "Name" },
                values: new object[,]
                {
                    { 637447773048974487L, "Store 1 Address", "One" },
                    { 637447773049007237L, "Store 2 Address", "Two" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "EntityID", "APizzaModelEntityID", "name", "price" },
                values: new object[,]
                {
                    { 637447773049017362L, null, "Cheese", 0.0 },
                    { 637447773049017888L, null, "Premium Chicken", 2.0 },
                    { 637447773049017904L, null, "Pulled Pork", 2.0 },
                    { 637447773049017914L, null, "Mushroom", 0.0 }
                });
        }
    }
}
