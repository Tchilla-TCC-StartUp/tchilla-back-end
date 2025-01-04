using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.UseCases.Cliente.Atualizar;

public class AtualizarClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;
    public AtualizarClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Result<string>> Executar(AtualizarClienteDto dto)
    {
        var cliente = new Domain.Entities.Cliente()
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Telefone = dto.Telefone,
            Email = dto.Email,
            Avatar = dto.Avatar
        };
        
        return (Result<string>) await _clienteRepository.AtualizarCliente(cliente);
    }
}