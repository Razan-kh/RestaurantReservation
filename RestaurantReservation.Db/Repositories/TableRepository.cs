using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class TableRepository
{
    private readonly RestaurantReservationDbContext _context;

    public TableRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    // CREATE
    public async Task AddTableAsync(Table table)
    {
        await _context.Tables.AddAsync(table);
        await _context.SaveChangesAsync();
    }

    // READ BY ID
    public async Task<Table?> GetTableByIdAsync(int id)
    {
        return await _context.Tables.FirstOrDefaultAsync(t => t.TableID == id);
    }

    // READ ALL
    public async Task<List<Table>> GetAllTablesAsync()
    {
        return await _context.Tables.ToListAsync();
    }

    // UPDATE
    public async Task UpdateTableAsync(Table table)
    {
        var existing = await _context.Tables.FindAsync(table.TableID);
        if (existing != null)
        {
            existing.Capacity = table.Capacity;
            existing.RestaurantID = table.RestaurantID;
            await _context.SaveChangesAsync();
        }
    }

    // DELETE
    public async Task DeleteTableAsync(int id)
    {
        var table = await _context.Tables.FindAsync(id);
        if (table != null)
        {
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }
    }
}