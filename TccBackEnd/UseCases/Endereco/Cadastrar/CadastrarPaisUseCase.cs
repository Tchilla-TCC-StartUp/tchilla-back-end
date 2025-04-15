using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Endereco.Dtos;

namespace TccBackEnd.UseCases.Endereco.Cadastrar;

public class CadastrarPaisUseCase
{
    private readonly IEnderecoRepository _repository;

    public CadastrarPaisUseCase(IEnderecoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Executar(CadastrarPaisDto dto)
    {
        Console.WriteLine($"Nome: {dto.Nome}");
        var novoPais = new Domain.Entities.Pais()
        {
            Nome = dto.Nome,
            CodigoIso = dto.CodigoIso
        };
        return await _repository.CriarPais(novoPais);
    }
}