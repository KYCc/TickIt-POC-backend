using DAL.EF;
using DAL.interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class TimeEntryRepository : ITimeEntryRepository
{
    private TickItDbContext dbContext;

    public TimeEntryRepository(TickItDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<TimeEntry?> GetById(Guid id)
    {
        return await dbContext.TimeEntries.FindAsync(id);
    }

    public async Task<IEnumerable<TimeEntry>> GetAll()
    {
        return await dbContext.TimeEntries.AsNoTracking().ToListAsync();
    }

    public async Task Add(TimeEntry timeEntry)
    {
        await dbContext.TimeEntries.AddAsync(timeEntry);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteById(Guid id)
    {
        var timeEntry = await GetById(id);
        if (timeEntry == null) return;
        
        dbContext.TimeEntries.Remove(timeEntry);
        await dbContext.SaveChangesAsync();
    }
}