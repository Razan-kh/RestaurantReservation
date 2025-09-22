using RestaurantReservation.Db;

public class RestaurantRevenueRepository
{
    private readonly RestaurantReservationDbContext _context;

    public RestaurantRevenueRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public decimal GetTotalRevenue(int restaurantId)
    {
        return _context.Restaurants
                       .Where(r => r.RestaurantID == restaurantId)
                       .Select(r => _context.CalculateTotalRevenue(r.RestaurantID))
                       .FirstOrDefault();
    }
}