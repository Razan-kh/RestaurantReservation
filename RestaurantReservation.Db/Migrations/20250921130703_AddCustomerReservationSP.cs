using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerReservationSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_MenuItem_ItemID",
                schema: "Restaurant",
                table: "OrderItem");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_MenuItem_ItemID",
                schema: "Restaurant",
                table: "OrderItem",
                column: "ItemID",
                principalSchema: "Restaurant",
                principalTable: "MenuItem",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_MenuItem_ItemID",
                schema: "Restaurant",
                table: "OrderItem");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_MenuItem_ItemID",
                schema: "Restaurant",
                table: "OrderItem",
                column: "ItemID",
                principalSchema: "Restaurant",
                principalTable: "MenuItem",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
