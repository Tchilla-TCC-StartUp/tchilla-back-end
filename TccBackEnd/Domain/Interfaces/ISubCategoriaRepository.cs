using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.SubCategoria.Dtos;

namespace TccBackEnd.Domain.Interfaces;

public interface ISubCategoriaRepository
{
    Task<Result<string>> CriarSubCategoria(SubCategoria categoria);
    Task<Result<string>> AtualizarSubCategoria(SubCategoria categoria);
    Task<Result<string>> RemoverSubCategoria(int id);
    Task<Result<List<SubCategoriaOutPutDto>>> ObterTodasSubCategorias();
}