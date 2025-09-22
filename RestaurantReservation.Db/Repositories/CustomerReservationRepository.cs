using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db;

namespace RestaurantReservation.Db.Repositories;

public class CustomerReservationRepository
{
    private readonly RestaurantReservationDbContext _context;

    public CustomerReservationRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetCustomersByPartySizeAsync(int partySize)
    {
        return await _context.Customers
            .FromSqlRaw("EXEC Restaurant.GetCustomersByPartySize @PartySize = {0}", partySize)
            .ToListAsync();
    }
}