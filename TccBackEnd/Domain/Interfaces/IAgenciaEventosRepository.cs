using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;

namespace TccBackEnd.Domain.Interfaces;

public interface IAgenciaEventosRepository
{
    Task<Result> CadastrarAgenciaEventos(AgenciaEventos agencia);
    Task<bool> AtualizarAgenciaEventos(AgenciaEventos agencia);
    Task<Result<AgenciaEventosOutputDto?>> ObterAgenciaEventosPorId(long id);
}

