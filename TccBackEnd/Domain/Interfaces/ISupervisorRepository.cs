using TccBackEnd.Domain.Entities;

namespace TccBackEnd.Domain.Interfaces;

public interface ISupervisorRepository
{
    Task<int> CadastrarSupervisor(Supervisor prestadorServico);
    Task<Supervisor?> ObterSupervisorPorId(long id);
}