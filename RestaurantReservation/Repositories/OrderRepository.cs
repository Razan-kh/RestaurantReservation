using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantReservation.Repositories;

public class OrderRepository
{
    private readonly RestaurantReservationDbContext _context;

    public OrderRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    // CREATE
    public async Task AddOrderAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    // READ
    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await _context.Orders
            .Include(o => o.Employee)
            .Include(o => o.Reservation)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
            .FirstOrDefaultAsync(o => o.OrderID == id);
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders
            .Include(o => o.Employee)
            .Include(o => o.Reservation)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
            .ToListAsync();
    }

    // UPDATE
    public async Task UpdateOrderAsync(Order order)
    {
        var existingOrder = await _context.Orders.FindAsync(order.OrderID);
        if (existingOrder != null)
        {
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.TotalAmount = order.TotalAmount;
            existingOrder.EmployeeID = order.EmployeeID;
            existingOrder.ReservationID = order.ReservationID;

            await _context.SaveChangesAsync();
        }
    }

    // DELETE
    public async Task DeleteOrderAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}