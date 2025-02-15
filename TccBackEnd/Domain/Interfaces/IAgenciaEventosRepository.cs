using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;

namespace TccBackEnd.Domain.Interfaces;

public interface IAgenciaEventosRepository
{
    Task<Result<string>> CadastrarAgenciaEventos(Agencia agencia);
    Task<Result<string>> AtualizarAgenciaEventos(Agencia agencia);
    Task<Result<AgenciaEventosOutputDto?>> ObterAgenciaEventosPorId(long id);
    Task<Result<List<AgenciaEventosOutputDto>?>> ObterTodasAgenciasEventos();
    Task<Result<List<AgenciaEventosOutputDto>?>> ObterTodasAgenciasEventosPorPesquisa(string consulta);
}

