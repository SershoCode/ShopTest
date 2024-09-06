namespace Shop.Application.Contracts;

public record AddPersonDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid ContactId { get; set; }
    public Guid FavoriteId { get; set; }
}
