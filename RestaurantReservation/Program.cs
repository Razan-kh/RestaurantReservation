using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation;

class Program
{
    static async Task Main()
    {
        using var context = new RestaurantReservationDbContext();
        var employeeRepository = new EmployeeRepository(context);

        using var customerContext = new RestaurantReservationDbContext();
        var customerRepository = new CustomerRepository(customerContext);

        using var menuContext = new RestaurantReservationDbContext();
        var menuItemRepository = new MenuItemRepository(menuContext);

        using var orderContext = new RestaurantReservationDbContext();
        var orderRepository = new OrderRepository(orderContext);

        var reservationContext = new RestaurantReservationDbContext();
        var reservationService = new ReservationRepository(reservationContext);

        using var restaurantContext = new RestaurantReservationDbContext();
        var restaurantRepository = new RestaurantRepository(restaurantContext);

        using var tableContext = new RestaurantReservationDbContext();
        var tableRepository = new TableRepository(tableContext);

        using var orderItemContext = new RestaurantReservationDbContext();
        var orderItemRepository = new OrderItemRepository(orderItemContext);

        /*

                var newItem = new MenuItem
                {
                    Name = "Cheeseburger",
                    Price = 9.99m,
                    Description = "Delicious cheeseburger with lettuce and tomato",
                    RestaurantID = 1 // Make sure restaurant with ID=1 exists
                };

                await menuService.AddMenuItemAsync(newItem);
                Console.WriteLine($"Added MenuItem: {newItem.Name}");

                // READ
                var item = await menuService.GetMenuItemByIdAsync(newItem.ItemID);
                if (item != null)
                    Console.WriteLine($"Retrieved MenuItem: {item.Name} - ${item.Price}");

                var allItems = await menuService.GetAllMenuItemsAsync();
                Console.WriteLine($"All MenuItems ({allItems.Count}):");
                foreach (var mi in allItems)
                    Console.WriteLine($"- {mi.Name}: ${mi.Price}");

                // UPDATE
                item.Price = 10.99m;
                item.Description = "Updated description: cheeseburger with extra cheese";
                await menuService.UpdateMenuItemAsync(item);
                Console.WriteLine($"Updated MenuItem: {item.Name} - ${item.Price}");

                // DELETE
                await menuService.DeleteMenuItemAsync(item.ItemID);
                Console.WriteLine($"Deleted MenuItem: {item.Name}");

                Console.WriteLine("Testing completed.");
                */
        /*
     ///-------------------------   order Item
                var newOrderItem = new OrderItem
                {
                    OrderID = 4,   
                    ItemID = 3,   
                    Quantity = 2
                };

                await orderItemRepositor.AddOrderItemAsync(newOrderItem);
                Console.WriteLine($"Added OrderItem with ID {newOrderItem.OrderItemID}");

                // 2. Update OrderItem
                newOrderItem.Quantity = 5;
                await orderItemRepositor.UpdateOrderItemAsync(newOrderItem);
                Console.WriteLine($"Updated OrderItem ID {newOrderItem.OrderItemID} quantity to {newOrderItem.Quantity}");

                // 3. Get OrderItem by ID
                var fetchedOrderItem = await orderItemRepositor.GetOrderItemByIdAsync(newOrderItem.OrderItemID);
                Console.WriteLine($"Fetched OrderItem: ID={fetchedOrderItem.OrderItemID}, Quantity={fetchedOrderItem.Quantity}");

                // 4. Get all OrderItems
                var allOrderItems = await orderItemRepositor.GetAllOrderItemsAsync();
                Console.WriteLine($"Total OrderItems: {allOrderItems.Count}");
                foreach (var oi in allOrderItems)
                {
                    Console.WriteLine($"OrderItem ID={oi.OrderItemID}, OrderID={oi.OrderID}, ItemID={oi.ItemID}, Quantity={oi.Quantity}");
                }

                // 5. Delete OrderItem
                await orderItemRepositor.DeleteOrderItemAsync(newOrderItem.OrderItemID);
                Console.WriteLine($"Deleted OrderItem with ID {newOrderItem.OrderItemID}");
            */
        //-------------------orderitem
        /*
        //order
          var newOrder = new Order
        {
            OrderDate = DateTime.Now,
            TotalAmount = 45.50m,
            EmployeeID = 3, // make sure this EmployeeID exists
            ReservationID = 3 // make sure this ReservationID exists
        };

        await orderService.AddOrderAsync(newOrder);
        Console.WriteLine($"Order {newOrder.OrderID} created.");

        // READ the order by ID
        var order = await orderService.GetOrderByIdAsync(newOrder.OrderID);
        Console.WriteLine($"Fetched Order: ID={order.OrderID}, Total={order.TotalAmount}");

        // UPDATE the order
        order.TotalAmount = 55.75m;
        await orderService.UpdateOrderAsync(order);
        Console.WriteLine($"Order {order.OrderID} updated. New Total={order.TotalAmount}");

        // GET ALL orders
        var allOrders = await orderService.GetAllOrdersAsync();
        Console.WriteLine($"Total Orders in DB: {allOrders.Count}");

        // DELETE the order
        await orderService.DeleteOrderAsync(order.OrderID);
        Console.WriteLine($"Order {order.OrderID} deleted.");

        // Confirm deletion
        var deletedOrder = await orderService.GetOrderByIdAsync(order.OrderID);
        Console.WriteLine(deletedOrder == null ? "Order successfully deleted." : "Order still exists!");
    */
        /*
        // -------------------------Reservations
           var newReservation = new Reservation
            {
                CustomerID = 3,
                RestaurantID = 3,
                TableID = 3,
                PartySize = 4,
                ReservationDate = DateTime.Now.AddDays(1)
            };

            await reservationService.AddReservationAsync(newReservation);
            Console.WriteLine($"Added Reservation ID: {newReservation.ReservationID}");

            // READ ALL
            var allReservations = reservationService.GetAllReservations();
            Console.WriteLine("All Reservations:");
            var list = await reservationService.GetAllReservations().ToListAsync();
            foreach (var res in list)
            {
                Console.WriteLine($"ReservationID: {res.ReservationID}, CustomerID: {res.CustomerID}, TableID: {res.TableID}");
            }

            // READ BY ID
            var fetchedReservation = await reservationService.GetReservationByIdAsync(newReservation.ReservationID);
            Console.WriteLine($"Fetched Reservation: {fetchedReservation.ReservationID}, PartySize: {fetchedReservation.PartySize}");

            // UPDATE
            fetchedReservation.PartySize = 6;
            await reservationService.UpdateReservationAsync(fetchedReservation);
            Console.WriteLine($"Updated Reservation ID {fetchedReservation.ReservationID} with new PartySize: {fetchedReservation.PartySize}");

            // DELETE
            await reservationService.DeleteReservationAsync(fetchedReservation.ReservationID);
            Console.WriteLine($"Deleted Reservation ID: {fetchedReservation.ReservationID}");
        */
        // CREATE
        /*
        //---------------------- Restaurants
         var newRestaurant = new Restaurant
         {
             Name = "Test Bistro",
             Address = "123 Test St",
             OpeningHours = "9:00 AM - 9:00 PM",
             PhoneNumber = "555-0000"
         };
         await restaurantRepository.AddRestaurantAsync(newRestaurant);
         Console.WriteLine($"Added Restaurant: {newRestaurant.Name}");

         // READ ALL
         var allRestaurants = await restaurantRepository.GetAllRestaurantsAsync();
         Console.WriteLine("All Restaurants:");
         foreach (var r in allRestaurants)
         {
             Console.WriteLine($"{r.RestaurantID}: {r.Name} - {r.Address}");
         }

         // READ BY ID
         var fetched = await restaurantRepository.GetRestaurantByIdAsync(newRestaurant.RestaurantID);
         if (fetched != null)
             Console.WriteLine($"Fetched Restaurant by ID: {fetched.Name}");

         // UPDATE
         fetched!.PhoneNumber = "555-1111";
         await restaurantRepository.UpdateRestaurantAsync(fetched);
         Console.WriteLine($"Updated Restaurant Phone: {fetched.PhoneNumber}");

         // DELETE
         await restaurantRepository.DeleteRestaurantAsync(fetched.RestaurantID);
         Console.WriteLine($"Deleted Restaurant: {fetched.Name}");
 */
        /*
        // --------------- Table
               var newTable = new Table
               {
                   Capacity = 4,
                   RestaurantID = 3 // Make sure this RestaurantID exists
               };
               await tableRepository.AddTableAsync(newTable);
               Console.WriteLine($"Added Table with ID: {newTable.TableID}");

               // READ BY ID
               var table = await tableRepository.GetTableByIdAsync(newTable.TableID);
               Console.WriteLine($"Fetched Table ID: {table?.TableID}, Capacity: {table?.Capacity}");

               // UPDATE
               if (table != null)
               {
                   table.Capacity = 6;
                   await tableRepository.UpdateTableAsync(table);
                   Console.WriteLine($"Updated Table ID: {table.TableID} to Capacity: {table.Capacity}");
               }

               // READ ALL
               var allTables = await tableRepository.GetAllTablesAsync();
               Console.WriteLine("All Tables:");
               foreach (var t in allTables)
               {
                   Console.WriteLine($"Table ID: {t.TableID}, Capacity: {t.Capacity}");
               }

               // DELETE
               await tableRepository.DeleteTableAsync(newTable.TableID);
               Console.WriteLine($"Deleted Table with ID: {newTable.TableID}");
               */
        // ------------------------ before async
        // CREATE
        /*
        var newManager = new Employee
        {
            FirstName = "Laura",
            LastName = "King",
            Position = "Manager",
            RestaurantID = 1
        };
        employeeService.AddEmployee(newManager);
        Console.WriteLine("Added new manager: Laura King");

        // READ
        var emp = employeeService.GetEmployee(newManager.EmployeeID);
        Console.WriteLine($"Retrieved Employee: {emp?.FirstName} {emp?.LastName}");

        // UPDATE
        emp.Position = "Senior Manager";
        employeeService.UpdateEmployee(emp);
        Console.WriteLine("Updated Employee position to Senior Manager");

        // LIST MANAGERS
        var managers = employeeService.ListManagers();
        Console.WriteLine("List of Managers:");
        foreach (var manager in managers)
        {
            Console.WriteLine($"{manager.FirstName} {manager.LastName} - {manager.Restaurant.Name}");
        }

        // DELETE
        employeeService.DeleteEmployee(emp.EmployeeID);
        Console.WriteLine("Deleted the employee.");

        customerService.AddCustomer(new Customer
        {
            FirstName = "Alice",
            LastName = "Johnson",
            Email = "alice@example.com",
            PhoneNumber = "555-1234"
        });

        // Get all customers
        var customers = customerService.GetAllCustomers();
        foreach (var c in customers)
        {
            Console.WriteLine($"{c.CustomerID}: {c.FirstName} {c.LastName}");
        }

        // Update a customer
        var customerToUpdate = customers.First();
        customerToUpdate.FirstName = "updatedName";
        customerService.UpdateCustomer(customerToUpdate);

        // Delete a customer
        customerService.DeleteCustomer(customerToUpdate.CustomerID);
        //-------------------
        menuService.AddMenuItem(new MenuItem
        {
            Name = "Cheeseburger",
            Price = 9.99m,
            Description = "Juicy burger with cheese",
            RestaurantID = 1
        });

        // Update a menu item
        var item = menuService.GetMenuItemById(2);
        item.Price = 10.50m;
        menuService.UpdateMenuItem(item);

        // Delete a menu item
        menuService.DeleteMenuItem(item.ItemID);

        // List all menu items
        var allItems = menuService.GetAllMenuItems();
        foreach (var i in allItems)
        {
            Console.WriteLine($"{i.ItemID}: {i.Name} - {i.Price:C}");
        }

        //----------------
        // Add a new order
        orderService.AddOrder(new Order
        {
            OrderDate = DateTime.Now,
            TotalAmount = 50.75m,
            EmployeeID = 1,
            ReservationID = 3
        });

        // Update an order
        var order = orderService.GetOrderById(3);
        order.TotalAmount = 55.00m;
        orderService.UpdateOrder(order);

        // Delete an order
        orderService.DeleteOrder(order.OrderID);

        // List all orders
        var orders = orderService.GetAllOrders();
        foreach (var o in orders)
        {
            Console.WriteLine($"{o.OrderID}: {o.TotalAmount:C} by Employee {o.EmployeeID}");
        }
        */
        //-------------

        /*
        //        Reservations
        var newReservation = new Reservation
        {
            CustomerID = 3,
            RestaurantID = 1,
            TableID = 1,
            PartySize = 2,
            ReservationDate = DateTime.Now.AddDays(1) // tomorrow
        };

        reservationService.AddReservation(newReservation);
        Console.WriteLine($"Added Reservation with ID: {newReservation.ReservationID}");

        // -----------------------------
        // 2. UPDATE the Reservation
        // -----------------------------
        newReservation.PartySize = 4; // update party size
        reservationService.UpdateReservation(newReservation);
        Console.WriteLine($"Updated Reservation {newReservation.ReservationID} to PartySize: {newReservation.PartySize}");

        // -----------------------------
        // 3. LIST all Reservations
        // -----------------------------
        Console.WriteLine("All Reservations:");
        foreach (var r in reservationService.GetAllReservations())
        {
            Console.WriteLine($"ID: {r.ReservationID}, CustomerID: {r.CustomerID}, RestaurantID: {r.RestaurantID}, TableID: {r.TableID}, PartySize: {r.PartySize}, Date: {r.ReservationDate}");
        }

        // -----------------------------
        // 4. DELETE the Reservation
        // -----------------------------
        reservationService.DeleteReservation(newReservation.ReservationID);
        Console.WriteLine($"Deleted Reservation with ID: {newReservation.ReservationID}");
        */
        /*
       // Restaurant
        var newRestaurant = new Restaurant
        {
            Name = "Burger Hub",
            Address = "123 Food St",
            OpeningHours = "10:00 AM - 10:00 PM",
            PhoneNumber = "555-0001"
        };
        restaurantService.AddRestaurant(newRestaurant);
        Console.WriteLine($"Added Restaurant ID: {newRestaurant.RestaurantID}");

        // READ
        var restaurant = restaurantService.GetRestaurantById(newRestaurant.RestaurantID);
        Console.WriteLine($"Retrieved Restaurant: {restaurant.Name}");

        // UPDATE
        restaurant.PhoneNumber = "555-9999";
        restaurantService.UpdateRestaurant(restaurant);
        Console.WriteLine($"Updated Restaurant Phone: {restaurant.PhoneNumber}");

        // DELETE
        restaurantService.DeleteRestaurant(restaurant.RestaurantID);
        Console.WriteLine($"Deleted Restaurant ID: {restaurant.RestaurantID}");
        */
        /*
        // Table
        var newTable = new Table
        {
            Capacity = 4,
            RestaurantID = 3
        };
        tableService.AddTable(newTable);
        Console.WriteLine($"Added Table ID: {newTable.TableID}");

        // READ
        var table = tableService.GetTableById(newTable.TableID);
        Console.WriteLine($"Retrieved Table Capacity: {table.Capacity}");

        // UPDATE
        table.Capacity = 6;
        tableService.UpdateTable(table);
        Console.WriteLine($"Updated Table Capacity: {table.Capacity}");

        // DELETE
        tableService.DeleteTable(table.TableID);
        Console.WriteLine($"Deleted Table ID: {table.TableID}");
        */

    }
}