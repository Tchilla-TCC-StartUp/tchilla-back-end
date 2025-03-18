using TccBackEnd.Domain.Entities;

namespace TccBackEnd.Domain.Interfaces;

public interface IPrestadorRepository
{
    Task<int> CadastrarPrestadorServico(Prestador prestadorServico);
    Task<Prestador?> ObterPrestadorServicoPorId(long id);
}