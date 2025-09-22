namespace RestaurantReservation.Db.Views;

public class RestaurantsEmployeesView
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }      
    public int RestaurantID { get; set; }
    public string Name { get; set; }          
    public string Address { get; set; }
    public string OpeningHours { get; set; }
    public string PhoneNumber { get; set; }    
}