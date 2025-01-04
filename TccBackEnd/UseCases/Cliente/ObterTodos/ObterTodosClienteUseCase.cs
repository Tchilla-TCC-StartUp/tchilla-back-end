using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.UseCases.Cliente.ObterTodos;

public class ObterTodosClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public ObterTodosClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Result<List<ClienteOutputDto>?>> Executar()
    {
        return (Result<List<ClienteOutputDto>?>) await _clienteRepository.ObterTodosClientes();
    }
}