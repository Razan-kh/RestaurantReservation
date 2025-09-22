using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

public class Table
{
    [Key]
    public int TableID { get; set; }

    public int Capacity { get; set; }

    [ForeignKey("Restaurant")]
    public int RestaurantID { get; set; }

    // Navigation
    public Restaurant Restaurant { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}