using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Local.Dtos;

namespace TccBackEnd.UseCases.Local.Atualizar;

public class AtualizarLocalUseCase
{
    private readonly ILocalRepository _repository;
    public AtualizarLocalUseCase(ILocalRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Executar(int userId ,CadastrarLocalDto dto)
    {
        var novoLocal = new Domain.Entities.Local()
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            PrecoHora = dto.PrecoHora
        };
        return await _repository.Create(novoLocal);
    }
}