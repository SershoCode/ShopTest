using AutoMapper;
using Microsoft.Extensions.Logging;
using Shop.Application.Contracts;
using Shop.Domain;

namespace Shop.Application;

public class PersonAppService : IPersonAppService
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<PersonAppService> _logger;

    public PersonAppService(IPersonRepository personRepository, IMapper mapper, ILogger<PersonAppService> logger)
    {
        _personRepository = personRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<PersonDto> AddAsync(AddPersonDto dto)
    {
        var id = Guid.NewGuid();

        var person = new Person(id, dto.FirstName, dto.LastName);

        await _personRepository.AddAsync(person);

        await _personRepository.SaveChangesAsync();

        return _mapper.Map<PersonDto>(person);
    }

    public async Task<PersonDto> GetAsync(Guid id)
    {
        _logger.LogInformation("[{AppService}] Get Person with Id: {Id} by AppService...", nameof(PersonAppService), id);

        var person = await _personRepository.GetByIdAsync(id);

        return _mapper.Map<PersonDto>(person);
    }
}
