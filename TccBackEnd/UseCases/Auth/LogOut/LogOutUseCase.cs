using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.UseCases.Auth.LogOut;

public class LogOutUseCase
{
  private readonly IAuthRepository _authRepository;
  public LogOutUseCase(IAuthRepository authRepository)
  {
    _authRepository = authRepository;
  }
  public async Task<Result<string>> Executar(int id)
  {
    return (Result<string>) await _authRepository.LogOut(id);
  }
}
