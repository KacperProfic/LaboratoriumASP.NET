using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebApp.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }

    [Required]
    [MaxLength(length: 20, ErrorMessage = "Imię nie może być dłuższe niż 20 znaków")]
    [MinLength(length: 2, ErrorMessage = "Imię musi mieć co najmniej 2 znaki!")]
    [Display(Name="Imię")]

    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(length: 50, ErrorMessage = "Nazwiwsko nie może być dłuższe niż 20 znaków")]
    [MinLength(length: 2, ErrorMessage = "Nazwisko musi mieć co najmniej 2 znaki!")]
    [Display(Name="Nazwisko")]
    public string LastName { get; set; }

    [EmailAddress]
    [Display(Name="Adres email")]
    public string Email { get; set; }
    
    [Phone]
    [RegularExpression(pattern:"\\d{3} \\d{3} \\d{3}", ErrorMessage = "Wpisz numer wg wzoru xxx xxx xxx")]
    [Display(Name="Numer telefonu")]
    public string PhoneNumber { get; set; }

    [DataType(DataType.Date)]
    [Display(Name="Data urodzenia")]
    public DateOnly BirthDate { get; set; }
    
    [Display(Name="Kategoria")]
    public Category Category { get; set; }


    [Display(Name="Organizacja")]
    [HiddenInput] 
    public int OrganizationId { get; set; }
    
    
    public OrganizationEntity? Organization { get; set; }
    
    
    [ValidateNever] public List<SelectListItem>? Organizations { get; set; }
}