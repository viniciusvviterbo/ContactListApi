namespace ContactList.Services;

using AutoMapper;
using ContactList.Entities;
using ContactList.Helpers;
using ContactList.Models.Contacts;

public interface IContactService
{
    IEnumerable<Contact> GetAll();
    Contact GetById(int id);
    IEnumerable<Contact> GetByPersonId(int id);
    void Create(CreateRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}

public class ContactService : IContactService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public ContactService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Contact> GetAll()
    {
        return _context.Contacts;
    }

    public Contact GetById(int id)
    {
        return getContact(id);
    }

    public IEnumerable<Contact> GetByPersonId(int id)
    {
        return getPersonsContacts(id);
    }

    public void Create(CreateRequest model)
    {
        // Map model to new contact object
        var contact = _mapper.Map<Contact>(model);

        // Save contact
        _context.Contacts.Add(contact);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateRequest model)
    {
        var contact = getContact(id);

        // Copy model to contact and save
        _mapper.Map(model, contact);
        _context.Contacts.Update(contact);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var contact = getContact(id);
        _context.Contacts.Remove(contact);
        _context.SaveChanges();
    }

    // Helper methods
    private Contact getContact(int id)
    {
        var contact = _context.Contacts.Find(id);
        if (contact == null) throw new KeyNotFoundException("Contact not found");
        return contact;
    }

    private IEnumerable<Contact> getPersonsContacts(int id)
    {
        IEnumerable<Contact> contacts = _context.Contacts.Where(c => c.PersonId == id).ToList();
        if (contacts == null || !contacts.Any()) throw new KeyNotFoundException("Contacts not found");
        return contacts;
    }
}