using TccBackEnd.Domain.Entities;

namespace TccBackEnd.Domain.Interfaces;

public interface ILocalRepository
{
    Task<List<Local>> GetAll();
    Task<Local> GetById(int id);   
    Task<Local> Create(Local local);
    Task<Local> Update(Local local);
    Task Delete(int id); 
}