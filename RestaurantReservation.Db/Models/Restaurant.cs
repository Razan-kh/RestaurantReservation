using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models;

public class Restaurant
{
    [Key]
    public int RestaurantID { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string Address { get; set; }

    [MaxLength(50)]
    public string OpeningHours { get; set; }

    [MaxLength(20)]
    public string PhoneNumber { get; set; }

    // Navigation
    public ICollection<Table> Tables { get; set; }
    public ICollection<Employee> Employees { get; set; }
    public ICollection<MenuItem> MenuItems { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}