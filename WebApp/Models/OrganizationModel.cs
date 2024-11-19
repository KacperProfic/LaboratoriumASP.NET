namespace WebApp.Models;

public class OrganizationModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string NIP { get; set; }
    public string REGON { get; set; }
    
    public Address Address { get; set; }
}