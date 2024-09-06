using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop.Domain;

namespace Shop.EntityFramework;

public class PersonRepository : IPersonRepository
{
    private readonly ShopDbContext _dbContext;
    private readonly ILogger<PersonRepository> _logger;

    public PersonRepository(ShopDbContext dbContext, ILogger<PersonRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task AddAsync(Person person)
    {
        _logger.LogInformation("[{Repository}] Adding Person with Id: {Id} by Repository...", nameof(PersonRepository), person);

        await _dbContext.AddAsync(person);
    }

    public Task<List<Person>> FindByFirstNameAsync(string firstName)
    {
        throw new NotImplementedException();
    }

    public Task<List<Person>> FindByLastNameAsync(string lastName)
    {
        throw new NotImplementedException();
    }

    public async Task<Person> GetByIdAsync(Guid id)
    {
        _logger.LogInformation("[{Repository}] Get Person with Id: {Id} by Repository...", nameof(PersonRepository), id);

        var person = await _dbContext.Persons.SingleAsync(p => p.Id == id);

        return person;
    }

    public Task<List<Person>> GetListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Person> RemoveAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Person> UpdateAsync(Guid id, string FirstName, string LastName, Guid? contractId, Guid? favoriteId)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
