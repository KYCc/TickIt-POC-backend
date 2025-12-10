using Domain;

namespace DAL.interfaces;

public interface IUserRepository
{
    public Task<User?> GetById(Guid id);
    public Task<IEnumerable<User>> GetAll();
    public Task Add(User user);
    public Task DeleteById(Guid id);
}