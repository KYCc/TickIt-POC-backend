using DAL.EF;
using DAL.interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class BusinessRepository : IBusinessRepository
{
    private readonly TickItDbContext dbContext;

    public BusinessRepository(TickItDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    // Retrieves a Business entity by its unique identifier without Users.
    public async Task<Business?> GetById(Guid id)
    {
        return await dbContext.Businesses.FindAsync(id);
    }

    public async Task<IEnumerable<Business>> GetAll()
    {
        return await dbContext.Businesses.AsNoTracking().ToListAsync();
    }

    public async Task Add(Business business)
    {
        await dbContext.Businesses.AddAsync(business);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteById(Guid id)
    {
        var business = await GetById(id);
        if (business == null) return;
        
        dbContext.Businesses.Remove(business);
        await dbContext.SaveChangesAsync();
    }
}