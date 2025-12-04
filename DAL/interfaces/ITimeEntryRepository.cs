using Domain;

namespace DAL.interfaces;

public interface ITimeEntryRepository
{
    public TimeEntry? GetById(int id);
    public IEnumerable<TimeEntry> GetAll();
    public void Add(TimeEntry timeEntry);
    public void DeleteById(int id);
}