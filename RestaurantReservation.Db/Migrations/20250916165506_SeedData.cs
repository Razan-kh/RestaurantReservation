using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Restaurant",
                table: "Customer",
                columns: new[] { "CustomerID", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "alice@email.com", "Alice", "Johnson", "555-1234" },
                    { 2, "bob@email.com", "Bob", "Smith", "555-2345" },
                    { 3, "charlie@email.com", "Charlie", "Davis", "555-3456" },
                    { 4, "diana@email.com", "Diana", "Evans", "555-4567" },
                    { 5, "ethan@email.com", "Ethan", "Brown", "555-5678" }
                });

            migrationBuilder.InsertData(
                schema: "Restaurant",
                table: "Restaurant",
                columns: new[] { "RestaurantID", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St", "Downtown Diner", "9:00 AM - 10:00 PM", "555-1234" },
                    { 2, "456 Elm St", "Pizza Palace", "11:00 AM - 11:00 PM", "555-1235" },
                    { 3, "789 Oak St", "Pasta Corner", "10:00 AM - 9:00 PM", "555-1236" },
                    { 4, "321 Pine St", "Salad Stop", "8:00 AM - 8:00 PM", "555-1237" },
                    { 5, "654 Maple Ave", "Seafood Shack", "12:00 PM - 12:00 AM", "555-1238" }
                });

            migrationBuilder.InsertData(
                schema: "Restaurant",
                table: "Employee",
                columns: new[] { "EmployeeID", "FirstName", "LastName", "Position", "RestaurantID" },
                values: new object[,]
                {
                    { 1, "John", "Manager", "Manager", 1 },
                    { 2, "Sara", "Manager", "Manager", 2 },
                    { 3, "Mike", "Chef", "Chef", 3 },
                    { 4, "Lucy", "Waiter", "Waiter", 4 },
                    { 5, "Tom", "Waiter", "Waiter", 5 }
                });

            migrationBuilder.InsertData(
                schema: "Restaurant",
                table: "MenuItem",
                columns: new[] { "ItemID", "Description", "Name", "Price", "RestaurantID" },
                values: new object[,]
                {
                    { 1, "Delicious cheeseburger", "Cheeseburger", 9.99m, 1 },
                    { 2, "Tasty pizza", "Pepperoni Pizza", 12.50m, 2 },
                    { 3, "Classic pasta", "Spaghetti", 11.00m, 3 },
                    { 4, "Fresh salad", "Caesar Salad", 8.25m, 4 },
                    { 5, "Juicy salmon", "Grilled Salmon", 15.50m, 5 }
                });

            migrationBuilder.InsertData(
                schema: "Restaurant",
                table: "Table",
                columns: new[] { "TableID", "Capacity", "RestaurantID" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 4, 1 },
                    { 3, 2, 2 },
                    { 4, 4, 3 },
                    { 5, 3, 4 }
                });

            migrationBuilder.InsertData(
                schema: "Restaurant",
                table: "Reservation",
                columns: new[] { "ReservationID", "CustomerID", "PartySize", "ReservationDate", "RestaurantID", "TableID" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 2, 2, new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 3, 3, 4, new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 4, 4, 3, new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 5, 5, 2, new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5 }
                });

            migrationBuilder.InsertData(
                schema: "Restaurant",
                table: "Order",
                columns: new[] { "OrderID", "EmployeeID", "OrderDate", "ReservationID", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 19.98m },
                    { 2, 2, new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 25.00m },
                    { 3, 3, new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 33.00m },
                    { 4, 4, new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 24.75m },
                    { 5, 5, new DateTime(2025, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 15.50m }
                });

            migrationBuilder.InsertData(
                schema: "Restaurant",
                table: "OrderItem",
                columns: new[] { "OrderItemID", "ItemID", "OrderID", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 2, 2 },
                    { 3, 3, 3, 3 },
                    { 4, 4, 4, 3 },
                    { 5, 5, 5, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Table",
                keyColumn: "TableID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "MenuItem",
                keyColumn: "ItemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "MenuItem",
                keyColumn: "ItemID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "MenuItem",
                keyColumn: "ItemID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "MenuItem",
                keyColumn: "ItemID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "MenuItem",
                keyColumn: "ItemID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Order",
                keyColumn: "OrderID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Order",
                keyColumn: "OrderID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Order",
                keyColumn: "OrderID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Order",
                keyColumn: "OrderID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Order",
                keyColumn: "OrderID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Employee",
                keyColumn: "EmployeeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Employee",
                keyColumn: "EmployeeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Employee",
                keyColumn: "EmployeeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Employee",
                keyColumn: "EmployeeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Employee",
                keyColumn: "EmployeeID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Reservation",
                keyColumn: "ReservationID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Reservation",
                keyColumn: "ReservationID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Reservation",
                keyColumn: "ReservationID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Reservation",
                keyColumn: "ReservationID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Reservation",
                keyColumn: "ReservationID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Restaurant",
                keyColumn: "RestaurantID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Table",
                keyColumn: "TableID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Table",
                keyColumn: "TableID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Table",
                keyColumn: "TableID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Table",
                keyColumn: "TableID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Restaurant",
                keyColumn: "RestaurantID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Restaurant",
                keyColumn: "RestaurantID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Restaurant",
                keyColumn: "RestaurantID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Restaurant",
                keyColumn: "RestaurantID",
                keyValue: 4);
        }
    }
}
