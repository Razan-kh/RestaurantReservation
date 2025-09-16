using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db;

public class RestaurantReservationDbContext : DbContext
{
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=RestaurantReservationCore;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>().ToTable("Restaurant", "Restaurant");
        modelBuilder.Entity<Customer>().ToTable("Customer", "Restaurant");
        modelBuilder.Entity<Table>().ToTable("Table", "Restaurant");
        modelBuilder.Entity<Employee>().ToTable("Employee", "Restaurant");
        modelBuilder.Entity<MenuItem>().ToTable("MenuItem", "Restaurant");
        modelBuilder.Entity<Reservation>().ToTable("Reservation", "Restaurant");
        modelBuilder.Entity<Order>().ToTable("Order", "Restaurant");
        modelBuilder.Entity<OrderItem>().ToTable("OrderItem", "Restaurant");

        modelBuilder.Entity<MenuItem>()
            .Property(m => m.Price)
            .HasColumnType("decimal(10,2)");

        modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasColumnType("decimal(10,2)");

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Table)
            .WithMany(t => t.Reservations)
            .HasForeignKey(r => r.TableID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Restaurant)
            .WithMany(res => res.Reservations)
            .HasForeignKey(r => r.RestaurantID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.CustomerID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.MenuItem)
            .WithMany(m => m.OrderItems)
            .HasForeignKey(oi => oi.ItemID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Restaurant>().HasData(
            new Restaurant { RestaurantID = 1, Name = "Downtown Diner", Address = "123 Main St", OpeningHours = "9:00 AM - 10:00 PM", PhoneNumber = "555-1234" },
            new Restaurant { RestaurantID = 2, Name = "Pizza Palace", Address = "456 Elm St", OpeningHours = "11:00 AM - 11:00 PM", PhoneNumber = "555-1235" },
            new Restaurant { RestaurantID = 3, Name = "Pasta Corner", Address = "789 Oak St", OpeningHours = "10:00 AM - 9:00 PM", PhoneNumber = "555-1236" },
            new Restaurant { RestaurantID = 4, Name = "Salad Stop", Address = "321 Pine St", OpeningHours = "8:00 AM - 8:00 PM", PhoneNumber = "555-1237" },
            new Restaurant { RestaurantID = 5, Name = "Seafood Shack", Address = "654 Maple Ave", OpeningHours = "12:00 PM - 12:00 AM", PhoneNumber = "555-1238" }
        );

        // Tables
        modelBuilder.Entity<Table>().HasData(
            new Table { TableID = 1, Capacity = 2, RestaurantID = 1 },
            new Table { TableID = 2, Capacity = 4, RestaurantID = 1 },
            new Table { TableID = 3, Capacity = 2, RestaurantID = 2 },
            new Table { TableID = 4, Capacity = 4, RestaurantID = 3 },
            new Table { TableID = 5, Capacity = 3, RestaurantID = 4 }
        );

        // Customers
        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerID = 1, FirstName = "Alice", LastName = "Johnson", Email = "alice@email.com", PhoneNumber = "555-1234" },
            new Customer { CustomerID = 2, FirstName = "Bob", LastName = "Smith", Email = "bob@email.com", PhoneNumber = "555-2345" },
            new Customer { CustomerID = 3, FirstName = "Charlie", LastName = "Davis", Email = "charlie@email.com", PhoneNumber = "555-3456" },
            new Customer { CustomerID = 4, FirstName = "Diana", LastName = "Evans", Email = "diana@email.com", PhoneNumber = "555-4567" },
            new Customer { CustomerID = 5, FirstName = "Ethan", LastName = "Brown", Email = "ethan@email.com", PhoneNumber = "555-5678" }
        );

        // Employees
        modelBuilder.Entity<Employee>().HasData(
            new Employee { EmployeeID = 1, FirstName = "John", LastName = "Manager", Position = "Manager", RestaurantID = 1 },
            new Employee { EmployeeID = 2, FirstName = "Sara", LastName = "Manager", Position = "Manager", RestaurantID = 2 },
            new Employee { EmployeeID = 3, FirstName = "Mike", LastName = "Chef", Position = "Chef", RestaurantID = 3 },
            new Employee { EmployeeID = 4, FirstName = "Lucy", LastName = "Waiter", Position = "Waiter", RestaurantID = 4 },
            new Employee { EmployeeID = 5, FirstName = "Tom", LastName = "Waiter", Position = "Waiter", RestaurantID = 5 }
        );

        // MenuItems
        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem { ItemID = 1, Name = "Cheeseburger", Description = "Delicious cheeseburger", Price = 9.99m, RestaurantID = 1 },
            new MenuItem { ItemID = 2, Name = "Pepperoni Pizza", Description = "Tasty pizza", Price = 12.50m, RestaurantID = 2 },
            new MenuItem { ItemID = 3, Name = "Spaghetti", Description = "Classic pasta", Price = 11.00m, RestaurantID = 3 },
            new MenuItem { ItemID = 4, Name = "Caesar Salad", Description = "Fresh salad", Price = 8.25m, RestaurantID = 4 },
            new MenuItem { ItemID = 5, Name = "Grilled Salmon", Description = "Juicy salmon", Price = 15.50m, RestaurantID = 5 }
        );

        // Reservations
        modelBuilder.Entity<Reservation>().HasData(
            new Reservation { ReservationID = 1, CustomerID = 1, RestaurantID = 1, TableID = 1, PartySize = 2, ReservationDate = new DateTime(2025, 9, 16) },
            new Reservation { ReservationID = 2, CustomerID = 2, RestaurantID = 2, TableID = 3, PartySize = 2, ReservationDate = new DateTime(2025, 9, 16) },
            new Reservation { ReservationID = 3, CustomerID = 3, RestaurantID = 3, TableID = 4, PartySize = 4, ReservationDate = new DateTime(2025, 9, 16) },
            new Reservation { ReservationID = 4, CustomerID = 4, RestaurantID = 4, TableID = 5, PartySize = 3, ReservationDate = new DateTime(2025, 9, 16) },
            new Reservation { ReservationID = 5, CustomerID = 5, RestaurantID = 5, TableID = 5, PartySize = 2, ReservationDate = new DateTime(2025, 9, 16) }
        );

        // Orders
        modelBuilder.Entity<Order>().HasData(
            new Order { OrderID = 1, ReservationID = 1, EmployeeID = 1, TotalAmount = 19.98m, OrderDate = new DateTime(2025, 9, 16) },
            new Order { OrderID = 2, ReservationID = 2, EmployeeID = 2, TotalAmount = 25.00m, OrderDate = new DateTime(2025, 9, 16) },
            new Order { OrderID = 3, ReservationID = 3, EmployeeID = 3, TotalAmount = 33.00m, OrderDate = new DateTime(2025, 9, 16) },
            new Order { OrderID = 4, ReservationID = 4, EmployeeID = 4, TotalAmount = 24.75m, OrderDate = new DateTime(2025, 9, 16) },
            new Order { OrderID = 5, ReservationID = 5, EmployeeID = 5, TotalAmount = 15.50m, OrderDate = new DateTime(2025, 9, 16) }
        );

        // OrderItems
        modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem { OrderItemID = 1, OrderID = 1, ItemID = 1, Quantity = 2 },
            new OrderItem { OrderItemID = 2, OrderID = 2, ItemID = 2, Quantity = 2 },
            new OrderItem { OrderItemID = 3, OrderID = 3, ItemID = 3, Quantity = 3 },
            new OrderItem { OrderItemID = 4, OrderID = 4, ItemID = 4, Quantity = 3 },
            new OrderItem { OrderItemID = 5, OrderID = 5, ItemID = 5, Quantity = 2 }
        );
    }
}