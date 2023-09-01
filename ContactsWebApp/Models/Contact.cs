namespace ContactsWebApp.Models;

public class Contact
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime Birthday { get; set; }

    public string VkId { get; set; }
}