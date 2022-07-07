namespace ContactList.Helpers;

using AutoMapper;
using ContactList.Entities;
using ContactList.Models.Contacts;
using ContactList.Models.Persons;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateRequest -> Contact
        CreateMap<ContactList.Models.Contacts.CreateRequest, Contact>();
        // CreateRequest -> Person
        CreateMap<ContactList.Models.Persons.CreateRequest, Person>();

        // UpdateRequest -> Contact
        CreateMap<ContactList.Models.Contacts.UpdateRequest, Contact>()
            .ForAllMembers(c => c.Condition(
                (src, dest, prop) =>
                {
                    // Ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    // Ignore null role
                    if (c.DestinationMember.Name == "Type" && src.Type == null) return false;

                    return true;
                }
            ));
        // UpdateRequest -> Person
        CreateMap<ContactList.Models.Persons.UpdateRequest, Person>()
            .ForAllMembers(p => p.Condition(
                (src, dest, prop) =>
                {
                    // Ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
    }
}