using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.UseCases.Cliente.Cadastrar;

public class LogarAgenciaUseCase
{
    private readonly IAuthRepository _authRepository;

    public LogarAgenciaUseCase(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<Result<string>> Executar(LogarCredenciaisDto dto)
    {
      return (Result<string>) await _authRepository.LogarAgencia(dto);
    }
}