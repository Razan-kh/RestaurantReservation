using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations;

protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.Sql(@"
        CREATE PROCEDURE [Restaurant].[GetCustomersByPartySize]
            @PartySize INT
        AS
        BEGIN
            SET NOCOUNT ON;
            SELECT c.*
            FROM [Restaurant].[Customer] AS c
            INNER JOIN [Restaurant].[Reservation] AS r
                ON c.CustomerID = r.CustomerID
            WHERE r.PartySize > @PartySize;
        END
    ");
}

protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.Sql("DROP PROCEDURE [Restaurant].[GetCustomersByPartySize]");
}