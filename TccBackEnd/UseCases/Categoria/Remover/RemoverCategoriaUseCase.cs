using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Categoria.Dtos;

namespace TccBackEnd.UseCases.Categoria.Remover;

public class RemoverCategoriaUseCase
{
    private readonly ICategoriaRepository _repository;

    public RemoverCategoriaUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Executar(int id)
    {
      return await _repository.RemoverCategoria(id);
    }
}