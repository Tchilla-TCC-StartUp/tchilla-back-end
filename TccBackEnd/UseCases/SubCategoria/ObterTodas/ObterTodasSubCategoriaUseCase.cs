using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.SubCategoria.Dtos;

namespace TccBackEnd.UseCases.SubCategoria.ObterTodas;

public class ObterTodasSubCategoriaUseCase
{
    private readonly ISubCategoriaRepository _repository;
    public ObterTodasSubCategoriaUseCase(ISubCategoriaRepository subCategoriaRepository)
    {
        _repository = subCategoriaRepository;   
    }
    public async Task<Result<List<SubCategoriaOutPutDto>>> Executar()
    {
        return await _repository.ObterTodasSubCategorias();
    }
}