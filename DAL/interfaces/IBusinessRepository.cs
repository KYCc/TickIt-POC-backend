using Domain;

namespace DAL.interfaces;

public interface IBusinessRepository
{
    public Task<Business?> GetById(Guid id);
    public Task<IEnumerable<Business>> GetAll();
    public Task Add(Business business);
    public Task DeleteById(Guid id);
}