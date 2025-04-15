using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Categoria.Dtos;
using TccBackEnd.UseCases.Search.Dtos;
using TccBackEnd.UseCases.Servico.Dtos;

namespace TccBackEnd.UseCases.Servico.ObterTodos;

public class RemoverServicoUseCase
{
  private readonly IServicoRepository _repository;

  public RemoverServicoUseCase(IServicoRepository repository)
  {
    _repository = repository;
  }

  public async Task<Result<string>> Executar(int id)
  {
    return await _repository.RemoverServico(id);
  }
}
