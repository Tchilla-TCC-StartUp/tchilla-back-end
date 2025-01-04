using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;

namespace TccBackEnd.Domain.Interfaces;

public interface IAgenciaEventosRepository
{
    Task<Result<string>> CadastrarAgenciaEventos(AgenciaEventos agencia);
    Task<Result<string>> AtualizarAgenciaEventos(AgenciaEventos agencia);
    Task<Result<AgenciaEventosOutputDto?>> ObterAgenciaEventosPorId(long id);
}

