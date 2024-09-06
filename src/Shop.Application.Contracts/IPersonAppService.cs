namespace Shop.Application.Contracts;

public interface IPersonAppService
{
    Task<PersonDto> AddAsync(AddPersonDto dto);
    Task<PersonDto> GetAsync(Guid id);
}
