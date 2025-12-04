using Domain;

namespace DAL.interfaces;

public interface IUserRepository
{
    public User? GetById(int id);
    public IEnumerable<User> GetAll();
    public void Add(User user);
    public void DeleteById(int id);
}