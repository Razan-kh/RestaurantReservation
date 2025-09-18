using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class ReservationRepository
{
    private readonly RestaurantReservationDbContext _context;

    public ReservationRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    // Add a new Reservation
    public async Task AddReservationAsync(Reservation reservation)
    {
        if (reservation == null)
            throw new ArgumentNullException(nameof(reservation));

        // Optional: Check foreign keys exist
        var customerExists = await _context.Customers.AnyAsync(c => c.CustomerID == reservation.CustomerID);
        var restaurantExists = await _context.Restaurants.AnyAsync(r => r.RestaurantID == reservation.RestaurantID);
        var tableExists = await _context.Tables.AnyAsync(t => t.TableID == reservation.TableID);

        if (!customerExists)
            throw new InvalidOperationException("Customer does not exist.");
        if (!restaurantExists)
            throw new InvalidOperationException("Restaurant does not exist.");
        if (!tableExists)
            throw new InvalidOperationException("Table does not exist.");

        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
    }

    // Update an existing Reservation
    public async Task UpdateReservationAsync(Reservation reservation)
    {
        if (reservation == null)
            throw new ArgumentNullException(nameof(reservation));

        var existing = await _context.Reservations.FirstOrDefaultAsync(r => r.ReservationID == reservation.ReservationID);
        if (existing == null)
            throw new InvalidOperationException("Reservation not found.");

        // Update fields
        existing.CustomerID = reservation.CustomerID;
        existing.RestaurantID = reservation.RestaurantID;
        existing.TableID = reservation.TableID;
        existing.PartySize = reservation.PartySize;
        existing.ReservationDate = reservation.ReservationDate;

        await _context.SaveChangesAsync();
    }

    // Delete a Reservation
    public async Task DeleteReservationAsync(int reservationId)
    {
        var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.ReservationID == reservationId);
        if (reservation == null)
            throw new InvalidOperationException("Reservation not found.");

        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
    }

    // Get all reservations
    public IQueryable<Reservation> GetAllReservations()
    {
        return _context.Reservations;
    }

    // Get reservation by ID
    public async Task<Reservation> GetReservationByIdAsync(int id)
    {
        return await _context.Reservations.FirstOrDefaultAsync(r => r.ReservationID == id);
    }
}