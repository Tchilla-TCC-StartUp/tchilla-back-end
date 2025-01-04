using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;

namespace TccBackEnd.UseCases.AgenciaEventos.ObterPorId;

public class ObterPorIdAgenciaEventosUseCase
{
    private readonly IAgenciaEventosRepository _agenciaEventosRepository;

    public ObterPorIdAgenciaEventosUseCase(IAgenciaEventosRepository agenciaEventosRepository)
    {
        _agenciaEventosRepository = agenciaEventosRepository;
    }
    public async Task<Result<AgenciaEventosOutputDto?>> Executar(long id)
    {
        return await _agenciaEventosRepository.ObterAgenciaEventosPorId(id);
    }
}