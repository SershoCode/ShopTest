namespace Shop.Application.Contracts;

public record PersonDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid ContactId { get; set; }
    public Guid FavoriteId { get; set; }
    public List<ProductDto> Products { get; }

    public PersonDto()
    {
        Products = [];
    }
}
