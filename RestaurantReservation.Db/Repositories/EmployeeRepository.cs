using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Repositories;

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
    var existingEmployee = await _context.Employees.FindAsync(employee.EmployeeID);
    if (existingEmployee != null)
    {
        existingEmployee.FirstName = employee.FirstName;
        existingEmployee.LastName = employee.LastName;
        existingEmployee.Position = employee.Position;
        existingEmployee.RestaurantID = employee.RestaurantID;

        await _context.SaveChangesAsync();
    }
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
    // Retrieves all employees who hold the position of "Manager
    public async Task<List<Employee>> ListManagers()
    {
        return await _context.Employees
                             .Where(e => e.Position == "Manager")
                             .ToListAsync();
    }

    // calculates the average order amount for that specific employee.
    public async Task<decimal> CalculateAverageOrderAmount(int employeeId)
    {
        var orders = _context.Orders
                .Where(o => o.EmployeeID == employeeId);
        
        if (!await orders.AnyAsync())
            return 0m; // No orders for this employee

        return await orders.AverageAsync(o => o.TotalAmount);
    }
}