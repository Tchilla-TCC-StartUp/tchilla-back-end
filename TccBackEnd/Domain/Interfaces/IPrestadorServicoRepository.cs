using TccBackEnd.Domain.Entities;

namespace TccBackEnd.Domain.Interfaces;

public interface IPrestadorServicoRepository
{
    Task<int> CadastrarPrestadorServico(Prestador prestadorServico);
    Task<PrestadorServico?> ObterPrestadorServicoPorId(long id);
}