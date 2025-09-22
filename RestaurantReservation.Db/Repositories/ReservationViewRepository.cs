using RestaurantReservation.Db.Views;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Repositories;

public class ReservationViewRepository
{
    private readonly RestaurantReservationDbContext _context;

    public ReservationViewRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ReservationDetailView>> GetAllReservationsWithDetailsAsync()
    {
        return await _context.Set<ReservationDetailView>().ToListAsync();
    }
}