namespace ContactList.Entities;

public class Contact
{
    public enum Label
    {
        Phone,
        Email,
        Whatsapp
    }

    public int Id { get; set; }
    
    public int PersonId { get; set; }

    public Label Type { get; set; }

    public string Value { get; set; }
}
