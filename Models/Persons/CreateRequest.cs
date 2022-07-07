namespace ContactList.Models.Persons;

using System.ComponentModel.DataAnnotations;

public class CreateRequest
{
    [Required]
    public string FirstName { get; set; }

    public string LastName { get; set; }
}