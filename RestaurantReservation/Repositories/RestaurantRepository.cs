using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Repositories;

public class RestaurantRepository
{
    private readonly RestaurantReservationDbContext _context;

    public RestaurantRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    // CREATE
    public async Task AddRestaurantAsync(Restaurant restaurant)
    {
        await _context.Restaurants.AddAsync(restaurant);
        await _context.SaveChangesAsync();
    }

    // READ
    public async Task<Restaurant?> GetRestaurantByIdAsync(int id)
    {
        return await _context.Restaurants
            .FirstOrDefaultAsync(r => r.RestaurantID == id);
    }

    public async Task<List<Restaurant>> GetAllRestaurantsAsync()
    {
        return await _context.Restaurants.ToListAsync();
    }

    // UPDATE
    public async Task UpdateRestaurantAsync(Restaurant restaurant)
    {
        var existing = await _context.Restaurants.FindAsync(restaurant.RestaurantID);
        if (existing != null)
        {
            existing.Name = restaurant.Name;
            existing.Address = restaurant.Address;
            existing.OpeningHours = restaurant.OpeningHours;
            existing.PhoneNumber = restaurant.PhoneNumber;
            await _context.SaveChangesAsync();
        }
    }

    // DELETE
    public async Task DeleteRestaurantAsync(int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        if (restaurant != null)
        {
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
        }
    }
}