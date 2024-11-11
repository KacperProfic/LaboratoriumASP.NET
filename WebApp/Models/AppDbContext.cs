using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    private string DbPath  { get; set; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
            {
                Id = 1,
                FirstName = "Kacper",
                LastName = "Dąbrowski",
                BirthDate = new DateOnly(2003, 11, 10),
                Email = "kacper@gmail.com",
                PhoneNumber = "888123188",
                Created = DateTime.Now
            },
            new ContactEntity()
            {
                Id = 2,
                FirstName = "Jan",
                LastName = "Kowalski",
                BirthDate = new DateOnly(2002, 08, 21),
                Email = "jan@gmail.com",
                PhoneNumber = "111999777",
                Created = DateTime.Now
            }
        );
    }
}