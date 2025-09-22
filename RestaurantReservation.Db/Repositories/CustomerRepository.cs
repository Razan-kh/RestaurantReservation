using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db;

namespace RestaurantReservation.Db.Repositories;

public class CustomerRepository
{
    private readonly RestaurantReservationDbContext _context;

    public CustomerRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    // CREATE
    public async Task AddCustomerAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    // READ
    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await _context.Customers
            .Include(c => c.Reservations)
            .FirstOrDefaultAsync(c => c.CustomerID == id);
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _context.Customers
            .Include(c => c.Reservations)
            .ToListAsync();
    }

    // UPDATE
    public async Task UpdateCustomerAsync(Customer customer)
    {
        var existingCustomer = await _context.Customers.FindAsync(customer.CustomerID);
        if (existingCustomer != null)
        {
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.PhoneNumber = customer.PhoneNumber;

            await _context.SaveChangesAsync();
        }
    }

    // DELETE
    public async Task DeleteCustomerAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}