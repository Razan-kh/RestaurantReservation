using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

public class OrderItem
{
    [Key]
    public int OrderItemID { get; set; }

    public int Quantity { get; set; }

    [ForeignKey("MenuItem")]
    public int ItemID { get; set; }

    [ForeignKey("Order")]
    public int OrderID { get; set; }

    // Navigation
    public MenuItem MenuItem { get; set; }
    public Order Order { get; set; }
}