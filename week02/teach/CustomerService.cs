/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Create a queue using an invalid maximum size (0).
        // Expected Result: The queue size should default to 10.
        // Defects Found: None. The constructor correctly defaults the size to 10.
        Console.WriteLine("Test 1 - Invalid Queue Size");
        var cs1 = new CustomerService(0);
        Console.WriteLine(cs1);
        Console.WriteLine("Expected: max_size should default to 10");

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Attempt to add more customers than the maximum queue size allows.
        // Expected Result: An error message should display when trying to add a customer
        // once the queue has reached its maximum capacity.
        // Defects Found: The original code used > instead of >= which allowed one extra
        // customer to be added beyond the maximum size.
        Console.WriteLine("Test 2 - Queue Full");
        var cs2 = new CustomerService(1);
        Console.WriteLine("Add one customer");
        cs2.AddNewCustomer();

        Console.WriteLine("Add second customer (should show error)");
        cs2.AddNewCustomer();

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Attempt to serve a customer when the queue is empty.
        // Expected Result: An error message should display indicating that there
        // are no customers in the queue.
        // Defects Found: The original code did not check if the queue was empty
        // before trying to remove a customer which caused an index error.
        Console.WriteLine("Test 3 - Serve Customer from Empty Queue");
        var cs3 = new CustomerService(3);
        cs3.ServeCustomer();
        Console.WriteLine("Expected: Error message for empty queue");

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Add multiple customers and then serve them.
        // Expected Result: Customers should be served in the same order they were added
        // (First In, First Out).
        // Defects Found: The original code removed the first customer before reading it,
        // which caused the second customer to be displayed instead.
        Console.WriteLine("Test 4 - FIFO Order");
        var cs4 = new CustomerService(5);
        cs4.AddNewCustomer();
        cs4.AddNewCustomer();
        cs4.ServeCustomer();
        Console.WriteLine("Expected: First customer entered should be served first");
    
        Console.WriteLine("=================");

        // Test 5
        // Scenario: Create a queue with an invalid size again to confirm
        // the default size behavior.
        // Expected Result: The queue should display a max size of 10.
        // Defects Found: None. The constructor correctly handles invalid input.
        Console.WriteLine("Test 5 - Default Queue Size");
        var cs5 = new CustomerService(0);
        Console.WriteLine(cs5);
        Console.WriteLine("Expected: max_size should default to 10");      
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue.
        //Corrected queue check as previous code allowed one extra customer.
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        //Add check to see if queue is empty before serving. 
        if (_queue.Count == 0) {
        Console.WriteLine("No customers in queue.");
        return;
        }

        //correct code as last code was removing first customer and printing second customer which violated the FIFO rules.
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}