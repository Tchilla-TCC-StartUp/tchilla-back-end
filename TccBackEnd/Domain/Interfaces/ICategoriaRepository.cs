using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Categoria.Dtos;

namespace TccBackEnd.Domain.Interfaces;

public interface ICategoriaRepository
{
  Task<Result<string>> CriarCategoria(Categoria categoria);
  Task<Result<string>> AtualizarCategoria(Categoria categoria);
  Task<Result<string>> RemoverCategoria(int id);
  Task<Result<List<CategoriaOutPutDto>>> ObterTodasCategorias();
}