using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.Domain.Interfaces;

public interface ISubCategoriaRepository
{
    Task<Result<string>> CriarSubCategoria(SubCategoria categoria);
    Task<Result<string>> AtualizarSubCategoria(SubCategoria categoria);
    Task<Result<string>> RemoverSubCategoria(SubCategoria categoria);
    Task<Result<string>> ObterTodasSubCategorias(SubCategoria categoria);
}