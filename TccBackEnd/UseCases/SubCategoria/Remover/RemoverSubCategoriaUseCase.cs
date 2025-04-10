using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.UseCases.SubCategoria.Remover;

public class RemoverSubCategoriaUseCase
{
    private readonly ISubCategoriaRepository _repository;
    public RemoverSubCategoriaUseCase(ISubCategoriaRepository subCategoriaRepository)
    {
        _repository = subCategoriaRepository;   
    }
    public async Task<Result<string>> Executar(int id)
    {
        return await _repository.RemoverSubCategoria(id);
    }
}