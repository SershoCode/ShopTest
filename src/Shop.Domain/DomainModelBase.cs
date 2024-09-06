namespace Shop.Domain;

public abstract class DomainModelBase<T> where T : class
{
    public Guid Id { get; private set; }

    protected string NameOfClass;

    protected DomainModelBase(Guid id)
    {
        Id = SetId(id);
        NameOfClass = typeof(T).Name;
    }

    private static Guid SetId(Guid id)
    {
        if (id == Guid.Empty)
            ThrowDomainException("Error on creating Domain Model. Id cannot be empty");

        return id;
    }

    protected static void ThrowDomainException(string message)
    {
        throw new DomainException(message);
    }
}
