using Domain;

namespace DAL.interfaces;

public interface IBusinessRepository
{
    public Business? GetById(int id);
    public IEnumerable<Business> GetAll();
    public void Add(Business business);
    public void DeleteById(int id);
}