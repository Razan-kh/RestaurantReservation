namespace RestaurantReservation.Db.Views;

public class ReservationDetailView
{
    public int ReservationID { get; set; }
    public int PartySize { get; set; }
    public DateTime ReservationDate { get; set; }
    public int CustomerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int RestaurantID { get; set; }
    public string RestaurantName { get; set; }
    public string RestaurantAddress { get; set; }
}