using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.Domain.Interfaces;

public interface IAuthRepository
{
  Task<Result<string>> LogarAgencia(LogarCredenciaisDto dto);
  Task<Result<string>> LogarCliente(LogarCredenciaisDto dto);
  Task<Result<string>> CadastrarCliente(Cliente cliente);
  Task<Result<string>> CadastrarAgencia(Agencia agencia);
  Task<Result<string>> LogOutCliente(long id);
  Task<Result<string>> ForgotPassword();
  Task<Result<string>> VerificarEmail();

}