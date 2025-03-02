using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.UseCases.Cliente.Cadastrar;

public class LogarClienteUseCase
{
    private readonly IAuthRepository _authRepository;

    public LogarClienteUseCase(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<Result<string>> Executar(LogarClienteDto dto)
    {
      return (Result<string>) await _authRepository.LogarCliente(dto);
    }
}