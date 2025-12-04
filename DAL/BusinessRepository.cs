using DAL.interfaces;
using Domain;

namespace DAL;

public class BusinessRepository : IBusinessRepository
{
    public Business? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Business> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Add(Business business)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}