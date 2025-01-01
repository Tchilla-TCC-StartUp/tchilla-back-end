using TccBackEnd.Domain.Entities;

namespace TccBackEnd.Domain.Interfaces;

public interface IClienteRepository
{
    Task<int> CadastrarCliente(Cliente cliente);
    Task<Cliente?> ObterClientePorId(long id);
}