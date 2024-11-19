using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext : IdentityDbContext<IdentityUser>
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
        base.OnModelCreating(modelBuilder);

        string ADMIN_ID = Guid.NewGuid().ToString();
        string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
        string USER_ID = Guid.NewGuid().ToString();
        string USER_ROLE_ID = Guid.NewGuid().ToString();

        modelBuilder.Entity<IdentityRole>()
            .HasData
            (
                new IdentityRole()
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = ADMIN_ROLE_ID
                },
                new IdentityRole()
                {
                    Id = USER_ROLE_ID,
                    Name = "user",
                    NormalizedName = "USER",
                    ConcurrencyStamp = USER_ROLE_ID
                }
            );

        var admin = new IdentityUser()
        {
            Id = ADMIN_ID,
            Email = "admin@gmail.com",
            NormalizedEmail = "admin@gmail.com".ToUpper(),
            UserName = "admin",
            NormalizedUserName = "admin".ToUpper(),
            EmailConfirmed = true,
        };
        
        var user = new IdentityUser()
        {
            Id = USER_ID,
            Email = "kamil@gmail.com",
            NormalizedEmail = "kamil@gmail.com".ToUpper(),
            UserName = "user",
            NormalizedUserName = "user".ToUpper(),
            EmailConfirmed = true,
        };

        PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
        admin.PasswordHash = hasher.HashPassword(admin, "1234@");
        user.PasswordHash = hasher.HashPassword(user, "4321@");

        modelBuilder.Entity<IdentityUser>()
            .HasData(admin, user);
        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>()
        {
            RoleId = ADMIN_ROLE_ID,
            UserId = admin.Id
        },
                new IdentityUserRole<string>()
                {
                    RoleId = USER_ROLE_ID,
                    UserId = user.Id
                }
        );
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