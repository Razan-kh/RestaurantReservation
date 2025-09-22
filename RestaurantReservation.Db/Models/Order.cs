using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

public class Order
{
    [Key]
    public int OrderID { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    [ForeignKey("Employee")]
    public int EmployeeID { get; set; }

    [ForeignKey("Reservation")]
    public int ReservationID { get; set; }

    // Navigation
    public Employee Employee { get; set; }
    public Reservation Reservation { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}