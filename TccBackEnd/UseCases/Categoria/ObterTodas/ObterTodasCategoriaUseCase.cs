using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Categoria.Dtos;

namespace TccBackEnd.UseCases.Categoria.Cadastrar;

public class ObterTodasCategoriaUseCase
{
    private readonly ICategoriaRepository _repository;

    public ObterTodasCategoriaUseCase(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<CategoriaOutPutDto>>> Executar()
    {
        return await _repository.ObterTodasCategorias();
    }
}