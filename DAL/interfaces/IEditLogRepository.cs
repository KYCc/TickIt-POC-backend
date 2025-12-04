using Domain;

namespace DAL.interfaces;

public interface IEditLogRepository
{
    public EditLog? GetById(int id);
    public IEnumerable<EditLog> GetAll();
    public void Add(EditLog editLog);
    public void DeleteById(int id);
}