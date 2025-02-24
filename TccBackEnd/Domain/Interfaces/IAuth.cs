using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.Domain.Interfaces;

public interface IAuth 
{
  Task<Result<string>> LogarCliente();
  Task<Result<string>> CadastrarCliente(Cliente cliente);
}