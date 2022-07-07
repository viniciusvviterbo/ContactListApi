namespace ContactList.Services;

using AutoMapper;
using ContactList.Entities;
using ContactList.Helpers;
using ContactList.Models.Persons;

public interface IPersonService
{
    IEnumerable<Person> GetAll();
    Person GetById(int id);
    void Create(CreateRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}

public class PersonService : IPersonService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public PersonService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Person> GetAll()
    {
        return _context.Persons;
    }

    public Person GetById(int id)
    {
        return getPerson(id);
    }

    public void Create(CreateRequest model)
    {
        // Map model to new person object
        var person = _mapper.Map<Person>(model);

        // Save person
        _context.Persons.Add(person);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateRequest model)
    {
        var person = getPerson(id);

        // Copy model to person and save
        _mapper.Map(model, person);
        _context.Persons.Update(person);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var person = getPerson(id);
        _context.Persons.Remove(person);
        _context.SaveChanges();
    }

    // Helper methods
    private Person getPerson(int id)
    {
        var person = _context.Persons.Find(id);
        if (person == null) throw new KeyNotFoundException("Person not found");
        return person;
    }
}