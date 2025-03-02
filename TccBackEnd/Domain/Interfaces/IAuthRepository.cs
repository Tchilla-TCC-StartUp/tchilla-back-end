using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.Domain.Interfaces;

public interface IAuthRepository
{
  Task<Result<string>> LogarCliente(LogarClienteDto dto);
  Task<Result<string>> CadastrarCliente(Cliente cliente);
  Task<Result<string>> LogOutCliente();
  Task<Result<string>> ForgotPassword();
  Task<Result<string>> VerificarEmail();

}