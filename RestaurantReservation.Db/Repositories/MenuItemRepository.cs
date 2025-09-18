using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantReservation.Db.Repositories;

public class MenuItemRepository
{
    private readonly RestaurantReservationDbContext _context;

    public MenuItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    // CREATE
    public async Task AddMenuItemAsync(MenuItem menuItem)
    {
        await _context.MenuItems.AddAsync(menuItem);
        await _context.SaveChangesAsync();
    }

    // READ
    public async Task<MenuItem?> GetMenuItemByIdAsync(int id)
    {
        return await _context.MenuItems
            .Include(m => m.Restaurant)
            .Include(m => m.OrderItems)
            .FirstOrDefaultAsync(m => m.ItemID == id);
    }

    public async Task<List<MenuItem>> GetAllMenuItemsAsync()
    {
        return await _context.MenuItems
            .Include(m => m.Restaurant)
            .Include(m => m.OrderItems)
            .ToListAsync();
    }

    // UPDATE
    public async Task UpdateMenuItemAsync(MenuItem menuItem)
    {
        var existingItem = await _context.MenuItems.FindAsync(menuItem.ItemID);
        if (existingItem != null)
        {
            existingItem.Name = menuItem.Name;
            existingItem.Price = menuItem.Price;
            existingItem.Description = menuItem.Description;
            existingItem.RestaurantID = menuItem.RestaurantID;

            await _context.SaveChangesAsync();
        }
    }

    // DELETE
    public async Task DeleteMenuItemAsync(int id)
    {
        var menuItem = await _context.MenuItems.FindAsync(id);
        if (menuItem != null)
        {
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
        }
    }
}