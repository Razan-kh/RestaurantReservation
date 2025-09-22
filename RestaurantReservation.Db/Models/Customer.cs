using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models;

public class Customer
{
    [Key]
    public int CustomerID { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; }

    [MaxLength(100)]
    public string Email { get; set; }

    [MaxLength(20)]
    public string PhoneNumber { get; set; }

    // Navigation
    public ICollection<Reservation> Reservations { get; set; }
}