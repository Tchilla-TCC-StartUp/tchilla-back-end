using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.UseCases.Cliente.ObterTodosPorPesquisa;

public class ObterTodosPorPesquisaClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public ObterTodosPorPesquisaClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Result<List<ClienteOutputDto>?>> Executar(string consulta)
    {
        return (Result<List<ClienteOutputDto>?>) await _clienteRepository.ObterTodosClientesPorPesquisa(consulta);
    }
}