using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class OrderItemRepository
{
    private readonly RestaurantReservationDbContext _context;

    public OrderItemRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    // Add a new OrderItem
    public async Task AddOrderItemAsync(OrderItem orderItem)
    {
        if (orderItem == null)
            throw new ArgumentNullException(nameof(orderItem));

        // Validate that the Order and MenuItem exist
        var orderExists = await _context.Orders.AnyAsync(o => o.OrderID == orderItem.OrderID);
        var menuItemExists = await _context.MenuItems.AnyAsync(m => m.ItemID == orderItem.ItemID);

        if (!orderExists)
            throw new InvalidOperationException("Order does not exist.");
        if (!menuItemExists)
            throw new InvalidOperationException("MenuItem does not exist.");

        await _context.OrderItems.AddAsync(orderItem);
        await _context.SaveChangesAsync();
    }

    // Update an existing OrderItem
    public async Task UpdateOrderItemAsync(OrderItem orderItem)
    {
        if (orderItem == null)
            throw new ArgumentNullException(nameof(orderItem));

        var existing = await _context.OrderItems
            .FirstOrDefaultAsync(oi => oi.OrderItemID == orderItem.OrderItemID);

        if (existing == null)
            throw new InvalidOperationException("OrderItem not found.");

        // Update fields
        existing.Quantity = orderItem.Quantity;
        existing.ItemID = orderItem.ItemID;
        existing.OrderID = orderItem.OrderID;

        await _context.SaveChangesAsync();
    }

    // Delete an OrderItem
    public async Task DeleteOrderItemAsync(int id)
    {
        var orderItem = await _context.OrderItems
            .FirstOrDefaultAsync(oi => oi.OrderItemID == id);

        if (orderItem == null)
            throw new InvalidOperationException("OrderItem not found.");

        _context.OrderItems.Remove(orderItem);
        await _context.SaveChangesAsync();
    }

    // Get all OrderItems
    public async Task<List<OrderItem>> GetAllOrderItemsAsync()
    {
        return await _context.OrderItems
            .Include(oi => oi.Order)
            .Include(oi => oi.MenuItem)
            .ToListAsync();
    }

    // Get OrderItem by ID
    public async Task<OrderItem> GetOrderItemByIdAsync(int id)
    {
        return await _context.OrderItems
            .Include(oi => oi.Order)
            .Include(oi => oi.MenuItem)
            .FirstOrDefaultAsync(oi => oi.OrderItemID == id);
    }
}