using TccBackEnd.Domain.Entities;

namespace TccBackEnd.Domain.Interfaces;

public interface IAgenciaEventosRepository
{
    Task<int> CadastrarAgenciaEventos(AgenciaEventos agencia);
    Task<bool> AtualizarAgenciaEventos(AgenciaEventos agencia);
    Task<AgenciaEventos?> ObterAgenciaEventosPorId(long id);
}

