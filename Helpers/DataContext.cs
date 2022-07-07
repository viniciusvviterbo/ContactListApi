namespace ContactList.Helpers;

using Microsoft.EntityFrameworkCore;
using ContactList.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {                
        // In memory database used for simplicity and non-persistent data
        options.UseInMemoryDatabase("TestDb"); 

        // Connect to sql server with connection string from app settings
        // options.UseSqlServer(Configuration.GetConnectionString("ContactListDatabase")); 
    }

    public DbSet<Contact> Contacts { get; set; }

    public DbSet<Person> Persons { get; set; }
}