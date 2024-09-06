namespace Shop.Domain;

public interface IPersonRepository
{
    public Task AddAsync(Person person);
    public Task<Person> GetByIdAsync(Guid id);
    public Task<List<Person>> FindByFirstNameAsync(string firstName);
    public Task<List<Person>> FindByLastNameAsync(string lastName);
    public Task<List<Person>> GetListAsync();
    public Task<Person> UpdateAsync(Guid id, string firstName, string lastName, Guid? contractId, Guid? favoriteId);
    public Task<Person> RemoveAsync(Guid id);
    public Task SaveChangesAsync();
}
