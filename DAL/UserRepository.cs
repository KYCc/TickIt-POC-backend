using DAL.EF;
using DAL.interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class UserRepository : IUserRepository
{
    private readonly TickItDbContext dbContext;

    public UserRepository(TickItDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<User?> GetById(Guid id)
    {
       return await dbContext.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await dbContext.Users.AsNoTracking().ToListAsync();
    }

    public async Task Add(User user)
    {
        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteById(Guid id)
    {
        var user = await GetById(id);
        if (user == null) return;
        
        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();
    }
}