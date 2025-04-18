using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.PrestadorServico.Dtos;

namespace TccBackEnd.Domain.Interfaces;

public interface IPrestadorRepository
{
    Task<PrestadorOutputDto> ObterPrestadorServicoPorId(long id);
    Task<Result<List<PrestadorOutputDto>>> ObterTodosPrestador();
}