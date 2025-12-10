using Domain;

namespace DAL.interfaces;

public interface IEditLogRepository
{
    public Task<EditLog?> GetById(Guid id);
    public Task<IEnumerable<EditLog>> GetAll();
    public Task Add(EditLog editLog);
    public Task DeleteById(Guid id);
}