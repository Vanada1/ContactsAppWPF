using ContactsWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebApp.Data;

public class ContactsAppDbContext : DbContext
{
    public ContactsAppDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Contact> Contacts { get; set; }
}