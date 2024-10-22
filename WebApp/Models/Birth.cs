namespace WebApp.Models;


public class Birth
{
    public string Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public string Message { get; set; }

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Name) && BirthDate.HasValue && BirthDate.Value < DateTime.Now;
    }

    public int CalculateAge()
    {
        if (!BirthDate.HasValue)
            return 0;

        var age = DateTime.Now.Year - BirthDate.Value.Year;
        if (DateTime.Now < BirthDate.Value.AddYears(age)) age--;

        return age;
    }
}
    
