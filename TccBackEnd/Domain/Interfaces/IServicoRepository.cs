using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Categoria.Dtos;
using TccBackEnd.UseCases.Servico.Dtos;

namespace TccBackEnd.Domain.Interfaces;

public interface IServicoRepository
{
  Task<Result<string>> CriarServicoAgencia(ServicoAgencia servico);
  Task<Result<string>> CriarServicoPrestador(ServicoPrestador servico);
  Task<Result<string>> AtualizarServicoPrestador(ServicoPrestador servico);
  Task<Result<string>> RemoverServico(int id);
  Task<Result<List<ServicoOutPutDto>>> ObterTodosServicos();
}