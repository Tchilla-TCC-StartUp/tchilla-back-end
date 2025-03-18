using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Auth.Dtos;

namespace TccBackEnd.UseCases.Auth.Logar;

public class LogarUseCase
{
    private readonly IAuthRepository _authRepository;

    public LogarUseCase(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<Result<string>> Executar(LogarCredenciaisDto dto)
    {
        return await _authRepository.Logar(dto);
    }
}
