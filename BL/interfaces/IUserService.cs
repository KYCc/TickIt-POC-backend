using Domain;
using Domain.enums;

namespace BL.interfaces;

public interface IUserService
{
    public Task<User?> GetById(Guid id);
    public Task<IEnumerable<User>> GetAll();
    public Task Add(string name, string email, string password, Role role, Guid businessId);
    public Task DeleteById(Guid id);
}