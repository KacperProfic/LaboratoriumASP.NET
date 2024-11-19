namespace WebApp.Models.Services;

public interface IOrganizationService
{
    void Add(OrganizationModel model);
    void Update(OrganizationModel model);
    void Delete(int id);
    List<OrganizationModel> GetAll();
    OrganizationModel? GetById(int id);
}