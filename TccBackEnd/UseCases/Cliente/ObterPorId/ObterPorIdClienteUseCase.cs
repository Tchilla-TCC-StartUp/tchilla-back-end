using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.UseCases.Cliente.ObterPorId;

public class ObterPorIdClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;
    public ObterPorIdClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Result<ClienteOutputDto?>> Executar(long id)
    {
        return (Result<ClienteOutputDto?>) await _clienteRepository.ObterClientePorId(id);
    }
}
