public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

// Customer.cs
public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetShippingLabel()
    {
        return $"{_name}\n{_address.GetFullAddress()}";
    }
}

// Product.cs
public class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetPackingLabel()
    {
        return $"{_name} (ID: {_productId})";
    }
}

// Order.cs
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal total = _products.Sum(p => p.GetTotalCost());
        decimal shippingCost = _customer.IsInUSA() ? 5 : 35;
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        return string.Join("\n", _products.Select(p => p.GetPackingLabel()));
    }

    public string GetShippingLabel()
    {
        return _customer.GetShippingLabel();
    }
}

// Program.cs
class Program
{
    static void Main()
    {
        // Creating Address and Customer
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);

        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Smith", address2);

        // Creating Orders
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "L123", 999.99m, 1));
        order1.AddProduct(new Product("Mouse", "M456", 25.50m, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "P789", 699.99m, 1));
        order2.AddProduct(new Product("Headphones", "H101", 79.99m, 1));

        // Display results
        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:\n" + order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.GetTotalPrice());
        Console.WriteLine("\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:\n" + order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.GetTotalPrice());
    }
}