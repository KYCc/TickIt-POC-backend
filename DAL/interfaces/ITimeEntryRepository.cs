using Domain;

namespace DAL.interfaces;

public interface ITimeEntryRepository
{
    public Task<TimeEntry?> GetById(Guid id);
    public Task<IEnumerable<TimeEntry>> GetAll();
    public Task Add(TimeEntry timeEntry);
    public Task DeleteById(Guid id);
}