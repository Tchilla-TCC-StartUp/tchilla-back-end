using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.Domain.Interfaces;

public interface ILocalRepository
{
    Task<List<Local>> GetAll();
    Task<Local> GetById(int id);   
    Task<Result<string>> Create(Local local);
    Task<Local> Update(Local local);
    Task<Result<string>> Delete(int id); 
}