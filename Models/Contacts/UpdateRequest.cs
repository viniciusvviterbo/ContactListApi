namespace ContactList.Models.Contacts;

using System.ComponentModel.DataAnnotations;
using ContactList.Entities;

public class UpdateRequest
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public int PersonId { get; set; }

    [Required]
    [EnumDataType(typeof(Contact.Label))]
    public string Type { get; set; }
    
    [Required]
    public string Value { get; set; }
}