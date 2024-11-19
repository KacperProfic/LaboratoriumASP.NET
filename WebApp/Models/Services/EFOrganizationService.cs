namespace WebApp.Models.Services;

public class EFOrganizationService : IOrganizationService
{
    private readonly AppDbContext _context;

    public EFOrganizationService(AppDbContext context)
    {
        _context = context;
    }

    public void Add(OrganizationModel model)
    {
        _context.Organizations.Add(OrganizationMapper.ToEntity(model));
        _context.SaveChanges();
    }

    public void Update(OrganizationModel model)
    {
        var entity = _context.Organizations.Find(model.Id);
        if (entity != null)
        {
            entity.Name = model.Name;
            entity.NIP = model.NIP;
            entity.REGON = model.REGON;
            _context.SaveChanges();
        }
        else
        {
            throw new Exception("Organization not found");
        }
    }

    public void Delete(int id)
    {
        _context.Organizations.Remove(new OrganizationEntity() { Id = id });
        _context.SaveChanges();
    }

    public List<OrganizationModel> GetAll()
    {
        return _context.Organizations
            .Select(e => OrganizationMapper.FromEntity(e))
            .ToList();
    }

    public OrganizationModel? GetById(int id)
    {
        var entity = _context.Organizations.Find(id);
        return entity != null ? OrganizationMapper.FromEntity(entity) : null;
    }
}
