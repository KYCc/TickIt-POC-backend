using BL.interfaces;
using DAL.interfaces;
using Domain;

namespace BL;

public class BusinessService : IBusinessService
{
    private readonly IBusinessRepository _businessRepository;

    public BusinessService(IBusinessRepository businessRepository)
    {
        this._businessRepository = businessRepository;
    }
    
    public async Task<Business?> GetById(Guid id)
    {
        return await _businessRepository.GetById(id);
    }

    public async Task<IEnumerable<Business>> GetAll()
    {
        return await _businessRepository.GetAll();
    }

    public async Task Add(string name)
    {
        var business = new Business
        {
            Id = Guid.NewGuid(),
            Name = name
        };
        
        await _businessRepository.Add(business);
    }

    public async Task DeleteById(Guid id)
    {
        await _businessRepository.DeleteById(id);
    }
}