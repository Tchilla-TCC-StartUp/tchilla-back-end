using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Local.Dtos;
using TccBackEnd.UseCases.PrestadorServico.Dtos;

namespace TccBackEnd.UseCases.Local.Atualizar;

public class ObterTodosPrestadorUseCase
{
    private readonly IPrestadorRepository _repository;
    public ObterTodosPrestadorUseCase(IPrestadorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<PrestadorOutputDto>>> Executar()
    {
        return await _repository.ObterTodosPrestador();
    }
}