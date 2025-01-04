using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Cliente.Dtos;

namespace TccBackEnd.UseCases.Cliente.Cadastrar;

public class CadastrarClienteUseCase
{
    private readonly IClienteRepository _clienteRepository;

    public CadastrarClienteUseCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Result<string>> Executar(CadastrarClienteDto dto)
    {
        var cliente = new Domain.Entities.Cliente()
        {
            Nome = dto.Nome,
            Nif = dto.Nif,
            Telefone = dto.Telefone,
            Email = dto.Email
        };
        
        return (Result<string>) await _clienteRepository.CadastrarCliente(cliente);
    }
}