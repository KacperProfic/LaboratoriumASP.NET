using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public DbSet<OrganizationEntity> Organizations { get; set; }
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

        modelBuilder.Entity<ContactEntity>()
            .HasOne<OrganizationEntity>(c => c.Organization)
            .WithMany(o => o.Contacts)
            .HasForeignKey(c => c.OrganizationId);

        modelBuilder.Entity<OrganizationEntity>()
            .ToTable("organizations")
            .HasData(
                new OrganizationEntity()
                {
                    Id = 101,
                    Name = "WSEI",
                    NIP = "8432443",
                    REGON = "73217313"
                },
                new OrganizationEntity()
                {
                    Id = 102,
                    Name = "ORLEN",
                    NIP = "3213133",
                    REGON = "3414314"
                }
            );
        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(o => o.Address)
            .HasData(
                new
                {
                    City = "Kraków", Street = "św. Filipa 12", OrganizationEntityId = 101
                },
                new
                {
                    City = "Wrocław", Street = "św. Filipa 15", OrganizationEntityId = 102
                }
            )
            ;
        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(o => o.Address)
            .Property(a => a.City)
            .IsRequired();
            
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity()
            {
                Id = 1,
                FirstName = "Kacper",
                LastName = "Dąbrowski",
                BirthDate = new DateOnly(2003, 11, 10),
                Email = "kacper@gmail.com",
                PhoneNumber = "888123188",
                Created = DateTime.Now,
                OrganizationId = 101
            },
            new ContactEntity()
            {
                Id = 2,
                FirstName = "Jan",
                LastName = "Kowalski",
                BirthDate = new DateOnly(2002, 08, 21),
                Email = "jan@gmail.com",
                PhoneNumber = "111999777",
                Created = DateTime.Now,
                OrganizationId = 101
            }
        );
    }
}