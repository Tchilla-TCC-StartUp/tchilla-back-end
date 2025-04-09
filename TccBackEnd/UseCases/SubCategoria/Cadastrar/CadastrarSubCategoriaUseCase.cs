using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.SubCategoria.Dtos;

namespace TccBackEnd.UseCases.SubCategoria.Cadastrar;

public class CadastrarSubCategoriaUseCase
{
    private readonly ISubCategoriaRepository _repository;
    public CadastrarSubCategoriaUseCase(ISubCategoriaRepository subCategoriaRepository)
    {
        _repository = subCategoriaRepository;   
    }
    public async Task<Result<string>> Executar(CadastrarSubCategoriaDto dto)
    {
        var novaSubCategoria = new Domain.Entities.SubCategoria()
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            Tipo = dto.Tipo,
            CategoriaId = dto.CategoriaId
        };
        return await _repository.CriarSubCategoria(novaSubCategoria);
    }
}