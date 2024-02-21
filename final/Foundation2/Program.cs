using System;
using System.Collections.Generic;

class Order
{
    public List<Product> Products { get; set; } = new List<Product>();
    public Customer Customer { get; set; }

    public Order(List<Product> products, Customer customer)
    {
        Products = products;
        Customer = customer;
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;

        foreach (var product in Products)
        {
            totalCost += product.CalculateTotalCost();
        }

        // Adding shipping cost based on customer location
        totalCost += Customer.IsInUSA() ? 5 : 35;

        return totalCost;
    }

    public string GetPackingLabel()
    {
        // Implementation for packing label
        return "Packing Label";
    }

    public string GetShippingLabel()
    {
        // Implementation for shipping label
        return "Shipping Label";
    }
}

class Product
{
    public string Name { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, int productId, decimal price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public decimal CalculateTotalCost()
    {
        return Price * Quantity;
    }
}

class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }
}

class Address
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string Country { get; set; }

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        StateProvince = stateProvince;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return $"{StreetAddress}, {City}, {StateProvince}, {Country}";
    }
}

class Program
{
    static void Main()
    {
        List<Product> products1 = new List<Product>
        {
            new Product("Product 1", 1, 10.99m, 2),
            new Product("Product 2", 2, 7.99m, 3),
        };

        List<Product> products2 = new List<Product>
        {
            new Product("Product 3", 3, 15.99m, 1),
            new Product("Product 4", 4, 5.99m, 4),
        };

        Customer customer1 = new Customer("Customer 1", new Address("123 Main St", "City1", "State1", "USA"));
        Customer customer2 = new Customer("Customer 2", new Address("456 Oak St", "City2", "State2", "Canada"));

        Order order1 = new Order(products1, customer1);
        Order order2 = new Order(products2, customer2);

        Console.WriteLine($"Order 1 Total Cost: {order1.CalculateTotalCost():C2}");
        Console.WriteLine($"Order 1 Packing Label: {order1.GetPackingLabel()}");
        Console.WriteLine($"Order 1 Shipping Label: {order1.GetShippingLabel()}\n");

        Console.WriteLine($"Order 2 Total Cost: {order2.CalculateTotalCost():C2}");
        Console.WriteLine($"Order 2 Packing Label: {order2.GetPackingLabel()}");
        Console.WriteLine($"Order 2 Shipping Label: {order2.GetShippingLabel()}");
    }
}
