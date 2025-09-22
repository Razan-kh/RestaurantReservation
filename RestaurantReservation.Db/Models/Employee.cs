using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

public class Employee
{
    [Key]
    public int EmployeeID { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; }

    [MaxLength(50)]
    public string Position { get; set; }

    [ForeignKey("Restaurant")]
    public int RestaurantID { get; set; }

    // Navigation
    public Restaurant Restaurant { get; set; }
    public ICollection<Order> Orders { get; set; }
}