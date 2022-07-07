namespace ContactList.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ContactList.Models.Persons;
using ContactList.Services;

[ApiController]
[Route("[controller]")]
public class PersonsController : ControllerBase
{
    private IPersonService _personService;
    private IMapper _mapper;

    public PersonsController(
        IPersonService personService,
        IMapper mapper)
    {
        _personService = personService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var persons = _personService.GetAll();
        return Ok(persons);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var person = _personService.GetById(id);
        return Ok(person);
    }

    [HttpPost]
    public IActionResult Create(CreateRequest model)
    {
        _personService.Create(model);
        return Ok(new { message = "Person created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _personService.Update(id, model);
        return Ok(new { message = "Person updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _personService.Delete(id);
        return Ok(new { message = "Person deleted" });
    }
}