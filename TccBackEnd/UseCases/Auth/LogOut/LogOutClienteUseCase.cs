using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.UseCases.Auth.LogOut;

public class LogOutClienteUseCase
{
  private readonly IAuthRepository _authRepository;
  public LogOutClienteUseCase(IAuthRepository authRepository)
  {
    _authRepository = authRepository;
  }
  public async Task<Result<string>> Executar(long id)
  {
    return (Result<string>) await _authRepository.LogOutCliente(id);
  }
}
