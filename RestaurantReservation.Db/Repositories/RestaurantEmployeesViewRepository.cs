using RestaurantReservation.Db;
using RestaurantReservation.Db.Views;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Repositories;

public class RestaurantEmployeesViewRepository
{
    private readonly RestaurantReservationDbContext _context;

    public RestaurantEmployeesViewRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<List<RestaurantsEmployeesView>> retrieveEmployeesWithRestaurants()
    {
       return await _context.RestaurantsEmployeesView.ToListAsync();
    }
}