using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.SubCategoria.Dtos;

namespace TccBackEnd.UseCases.SubCategoria.ObterTodas;

public class ObterTodasPorCategoriaUseCase
{
    private readonly ISubCategoriaRepository _repository;
    public ObterTodasPorCategoriaUseCase(ISubCategoriaRepository subCategoriaRepository)
    {
        _repository = subCategoriaRepository;   
    }
    public async Task<Result<List<SubCategoriaOutPutDto>>> Executar(int categoriaId)
    {
        return await _repository.ObterTodasSubCategoriasPorCategoria(categoriaId);
    }
}