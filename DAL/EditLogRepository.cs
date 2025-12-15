using DAL.EF;
using DAL.interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class EditLogRepository : IEditLogRepository
{
    private readonly TickItDbContext dbContext;

    public EditLogRepository(TickItDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<EditLog?> GetById(Guid id)
    {
        return await dbContext.EditLogs.FindAsync(id);
    }

    public async Task<IEnumerable<EditLog>> GetAll()
    {
        return await dbContext.EditLogs.AsNoTracking().ToListAsync();
    }

    public async Task Add(EditLog editLog)
    {
        await dbContext.EditLogs.AddAsync(editLog);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteById(Guid id)
    {
        var editLog = await GetById(id);
        if (editLog == null) return;
        
        dbContext.EditLogs.Remove(editLog);
        await dbContext.SaveChangesAsync();
    }
}