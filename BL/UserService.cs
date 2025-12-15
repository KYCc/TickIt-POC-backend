using BL.interfaces;
using DAL.interfaces;
using Domain;
using Domain.enums;
using BCrypt.Net;

namespace BL;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }
    
    public async Task<User?> GetById(Guid id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _userRepository.GetAll();
    }

    public async Task Add(string name, string email, string password, Role role, Guid businessId)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
            Role = role,
            BusinessId = businessId
        };
        await _userRepository.Add(user);
    }

    public async Task DeleteById(Guid id)
    {
        await _userRepository.DeleteById(id);
    }
}