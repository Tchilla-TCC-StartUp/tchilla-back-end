using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Endereco.Dtos;

namespace TccBackEnd.UseCases.Endereco.Cadastrar;

public class CadastrarProvinciaUseCase
{
    private readonly IEnderecoRepository _repository;

    public CadastrarProvinciaUseCase(IEnderecoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Executar(CadastrarProvinciaDto dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        var novaProvincia = new Domain.Entities.Provincia()
        {
            Nome = dto.Nome,
            PaisId = dto.PaisId
        };
        return await _repository.CriarProvincia(novaProvincia);
    }
}