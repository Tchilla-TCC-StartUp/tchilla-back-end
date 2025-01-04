using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.Domain.Interfaces;

public interface IClienteRepository
{
    Task<Result<string>> CadastrarCliente(Cliente cliente);
    Task<Result<string>> AtualizarCliente(Cliente cliente);
    Task<Result<ClienteOutputDto?>> ObterClientePorId(long id);
}