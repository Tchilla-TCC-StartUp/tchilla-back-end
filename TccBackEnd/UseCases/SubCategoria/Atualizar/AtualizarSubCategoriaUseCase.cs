using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.SubCategoria.Dtos;

namespace TccBackEnd.UseCases.SubCategoria.Cadastrar;

public class AtualizarSubCategoriaUseCase
{
    private readonly ISubCategoriaRepository _repository;
    public AtualizarSubCategoriaUseCase(ISubCategoriaRepository subCategoriaRepository)
    {
        _repository = subCategoriaRepository;   
    }
    public async Task<Result<string>> Executar(int id, CadastrarSubCategoriaDto dto)
    {
        var novaSubCategoria = new Domain.Entities.SubCategoria()
        {
            Id = id,
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            Tipo = dto.Tipo,
            CategoriaId = dto.CategoriaId
        };
        return await _repository.AtualizarSubCategoria(novaSubCategoria);
    }
}