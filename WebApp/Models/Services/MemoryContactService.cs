namespace WebApp.Models.Services;

public class MemoryContactService : IContactService
{
    private Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1,
            new ContactModel()
            {
                Id = 1,
                Category = Category.Business,
                FirstName = "Adam",
                LastName = "Abecki",
                Email = "adam@wsei.edu.pl",
                PhoneNumber = "222 333 222",
                BirthDate = new DateOnly(2000,10,10)
            }
            
        },
        {
            2,
            new ContactModel()
            {
                Id = 2,
                Category = Category.Family,
                FirstName = "Ewa",
                LastName = "Sala",
                Email = "ewa@wsei.edu.pl",
                PhoneNumber = "212 343 222",
                BirthDate = new DateOnly(2002, 03, 01)
            }
            
        },

    };

    private  int currentId = 3;
    public void Add(ContactModel model)
    {
        model.Id = ++currentId;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel model)
    {
        if (_contacts.ContainsKey(model.Id))
        {
            _contacts[model.Id] = model;
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        return _contacts[id];
    }

    public List<OrganizationEntity> GetOrganzations()
    {
        throw new NotImplementedException();
    }
}