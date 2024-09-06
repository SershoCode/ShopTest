using Shop.Utils;
using System.Collections.ObjectModel;

namespace Shop.Domain;

public class Person : DomainModelBase<Person>, IAggregateRoot
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Guid? ContactId { get; private set; }
    public Guid? FavoriteId { get; private set; }
    public ReadOnlyCollection<Product> Products { get; }

    private readonly List<Product> _products;

    public Person(Guid id, string firstName, string lastName) : base(id)
    {
        _products = [];

        FirstName = SetFirstName(firstName);
        LastName = SetLastName(lastName);
        Products = _products.AsReadOnly();
    }

    #region Business Operations

    public void AddProduct(Product product)
    {
        const string nameOfParameter = nameof(product);

        if (product == null)
            ThrowDomainException($"Error on adding ${nameOfParameter} to ${NameOfClass}. {nameOfParameter} cannot be null");

        _products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        RemoveProduct(product.Id);
    }

    public void RemoveProduct(Guid productId)
    {
        _products.RemoveAll(p => p.Id == productId);
    }

    #endregion

    #region Fluent Changers

    public Person ChangeFirstName(string firstName)
    {
        FirstName = SetFirstName(firstName);

        return this;
    }

    public Person ChangeLastName(string lastName)
    {
        LastName = SetLastName(lastName);

        return this;
    }

    public Person ChangeContactId(Guid contactId)
    {
        ContactId = SetContactId(contactId);

        return this;
    }

    public Person ChangeFavoriteId(Guid favoriteId)
    {
        FavoriteId = SetFavoriteId(favoriteId);

        return this;
    }

    #endregion

    #region Private Setters

    private string SetFirstName(string firstName)
    {
        const string nameOfParameter = nameof(firstName);

        if (string.IsNullOrEmpty(firstName))
            ThrowDomainException($"Error on setting {nameOfParameter} of {NameOfClass}. Parameter cannot be null or empty. Requested: '{firstName}'");

        if (firstName.Contains(' '))
            ThrowDomainException($"Error on setting {nameOfParameter} of {NameOfClass}. Parameter cannot be contains whitespaces. Requested: '{firstName}'");

        if (firstName.Length < 3 || firstName.Length > 30)
            ThrowDomainException($"Error on setting {nameOfParameter} of {NameOfClass}. Parameter cannot be shorter than 3 characters or longer than 30. Requested: '{firstName}'");

        return firstName.FirstCharToUpper();
    }

    private string SetLastName(string lastName)
    {
        const string nameOfParameter = nameof(lastName);

        if (string.IsNullOrEmpty(lastName))
            ThrowDomainException($"Error on setting {nameOfParameter} of {NameOfClass}. Parameter cannot be null or empty. Requested: '{lastName}'");

        if (lastName.Contains(' '))
            ThrowDomainException($"Error on setting {nameOfParameter} of {NameOfClass}. Parameter cannot be contains whitespaces. Requested: '{lastName}'");

        if (lastName.Length < 3 || lastName.Length > 30)
            ThrowDomainException($"Error on setting {nameOfParameter} of {NameOfClass}. Parameter cannot be shorter than 3 characters or longer than 30. Requested: '{lastName}'");

        return lastName.FirstCharToUpper();
    }

    private Guid SetContactId(Guid contactId)
    {
        const string nameOfParameter = nameof(contactId);

        if (contactId == Guid.Empty)
            ThrowDomainException($"Error on setting {nameOfParameter} of {NameOfClass}. Parameter cannot be empty. Requested: {contactId}");

        return contactId;
    }

    private Guid SetFavoriteId(Guid favoriteId)
    {
        const string nameOfParameter = nameof(favoriteId);

        if (favoriteId == Guid.Empty)
            ThrowDomainException($"Error on setting {nameOfParameter} of {NameOfClass}. Parameter cannot be empty. Requested: {favoriteId}");

        return favoriteId;
    }

    #endregion
}
