using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

public class MenuItem
{
    [Key]
    public int ItemID { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    public decimal Price { get; set; }

    [MaxLength(200)]
    public string Description { get; set; }

    [ForeignKey("Restaurant")]
    public int RestaurantID { get; set; }

    // Navigation
    public Restaurant Restaurant { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}