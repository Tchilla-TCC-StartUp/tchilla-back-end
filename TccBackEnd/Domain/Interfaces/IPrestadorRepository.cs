using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.Domain.Interfaces;

public interface IPrestadorRepository
{
    Task<Prestador?> ObterPrestadorServicoPorId(long id);
}