using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models;

[Table("contacts")]
public class ContactEntity
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(20)]
    [MinLength(2)]
    [DisplayAttribute(Name = "Imię")]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    [MinLength(2)]
    [DisplayAttribute(Name = "Nazwisko")]
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    [Column("birth")]
    public DateOnly BirthDate { get; set; }

    public DateTime Created { get; set;  }

    public int OrganizationId { get; set; }

    public OrganizationEntity? Organization { get; set; }
}