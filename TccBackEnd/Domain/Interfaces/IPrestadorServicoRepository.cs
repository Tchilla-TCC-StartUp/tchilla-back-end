using TccBackEnd.Domain.Entities;

namespace TccBackEnd.Domain.Interfaces;

public interface IPrestadorServicoRepository
{
    Task<int> CadastrarPrestadorServico(PrestadorServico prestadorServico);
    Task<PrestadorServico?> ObterPrestadorServicoPorId(long id);
}