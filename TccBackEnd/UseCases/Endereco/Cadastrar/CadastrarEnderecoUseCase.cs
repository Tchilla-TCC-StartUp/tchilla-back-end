using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Endereco.Dtos;

namespace TccBackEnd.UseCases.Endereco.Cadastrar;

public class CadastrarEnderecoUseCase
{
    private readonly IEnderecoRepository _repository;

    public CadastrarEnderecoUseCase(IEnderecoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Executar(CadastrarEnderecoDto dto)
    {
        if (dto is null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        var novoEndereco = new Domain.Entities.Endereco()
        {
            Cep = dto.Cep,
            Numero = dto.Numero,    
            Principal = dto.Principal,
            Cidade = dto.Cidade,
            Rua = dto.Rua,
            UsuarioId = dto.UsuarioId,
            ProvinciaId = dto.ProvinciaId,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude
        };
        return await _repository.CriarEndereco(novoEndereco);
    }
}