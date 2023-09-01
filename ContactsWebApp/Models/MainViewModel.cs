namespace ContactsWebApp.Models;

public class MainViewModel
{
    public List<Contact> Contacts { get; set; }

    public Contact? SelectContact { get; set; }
}