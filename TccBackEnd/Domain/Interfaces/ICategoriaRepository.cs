using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.Domain.Interfaces;

public interface ICategoriaRepository
{
  Task<Result<string>> CriarCategoria(Categoria categoria);
  Task<Result<string>> AtualizarCategoria(Categoria categoria);
  Task<Result<string>> RemoverCategoria(Categoria categoria);
  Task<Result<string>> ObterTodasCategorias(Categoria categoria);
}