using Shop.Utils;

namespace Shop.Domain;

public class Product : DomainModelBase<Product>
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Product(Guid id, string name, decimal price) : base(id)
    {
        Name = name;
        Price = price;
    }

    public Product ChangeName(string name)
    {
        Name = SetName(name);

        return this;
    }

    public Product ChangePrice(decimal price)
    {
        Price = SetPrice(price);

        return this;
    }

    private string SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            ThrowDomainException($"Error on setting name of ${nameof(Product)}. {nameof(name)} cannot be null or empty");

        if (name.Length < 3 || name.Length > 30)
            ThrowDomainException($"Error on setting name of ${nameof(Product)}. {nameof(name)} cannot be shorter than 3 characters or longer than 30");

        return name.FirstCharToUpper();
    }

    private decimal SetPrice(decimal price)
    {
        if (price <= 0)
            ThrowDomainException($"Error on setting price of ${nameof(Product)}. {nameof(price)} cannot be <= 0");

        return price;
    }
}
