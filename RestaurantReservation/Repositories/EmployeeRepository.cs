using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Repositories;

public class EmployeeRepository
{
    private readonly RestaurantReservationDbContext _context;

    public EmployeeRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    // CREATE
    public async Task AddEmployeeAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    // READ
    public async Task<Employee?> GetEmployeeAsync(int id)
    {
        return await _context.Employees
            .Include(e => e.Restaurant)
            .FirstOrDefaultAsync(e => e.EmployeeID == id);
    }

    // UPDATE
    public async Task UpdateEmployeeAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    // DELETE
    public async Task DeleteEmployeeAsync(int id)
    {
        var emp = await _context.Employees.FindAsync(id);
        if (emp != null)
        {
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
        }
    }
}