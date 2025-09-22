using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

public class Reservation
{
    [Key]
    public int ReservationID { get; set; }

    [ForeignKey("Customer")]
    public int CustomerID { get; set; }

    [ForeignKey("Restaurant")]
    public int RestaurantID { get; set; }

    [ForeignKey("Table")]
    public int TableID { get; set; }

    public int PartySize { get; set; }

    public DateTime ReservationDate { get; set; }

    // Navigation
    public Customer Customer { get; set; }
    public Restaurant Restaurant { get; set; }
    public Table Table { get; set; }
    public ICollection<Order> Orders { get; set; }
}