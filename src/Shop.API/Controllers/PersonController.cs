using Microsoft.AspNetCore.Mvc;
using Shop.Application.Contracts;
using Shop.Domain;

namespace Shop.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonAppService _personAppService;
    private readonly ILogger<PersonController> _logger;

    public PersonController(IPersonAppService personAppService, ILogger<PersonController> logger)
    {
        _personAppService = personAppService;
        _logger = logger;
    }

    [Produces(typeof(Person))]
    [HttpGet(Name = "GetPerson")]
    public async Task<ActionResult<PersonDto>> Get(Guid id)
    {
        try
        {
            _logger.LogInformation("[{Controller}] Get Person with Id: {Id} by Controller...", nameof(PersonController), id);

            var person = await _personAppService.GetAsync(id);

            return person;
        }
        catch (DomainException ex)
        {
            return BadRequest($"Domain Exception on request: {ex.Message}");
        }
        catch (Exception ex)
        {
            return BadRequest($"Unhandled Exception on request: {ex.Message}");
        }
    }

    [Produces(typeof(Person))]
    [HttpPost(Name = "GetPerson")]
    public async Task<ActionResult<PersonDto>> Add(AddPersonDto dto)
    {
        try
        {
            var personDto = await _personAppService.AddAsync(dto);

            return personDto;
        }
        catch (DomainException ex)
        {
            return BadRequest($"Domain Exception on request: {ex.Message}");
        }
        catch (Exception ex)
        {
            return BadRequest($"Unhandled Exception on request: {ex.Message}");
        }
    }
}
