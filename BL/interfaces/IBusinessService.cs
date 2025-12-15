using Domain;

namespace BL.interfaces;

public interface IBusinessService
{
    public Task<Business?> GetById(Guid id);
    public Task<IEnumerable<Business>> GetAll();
    public Task Add(string name);
    public Task DeleteById(Guid id);
}