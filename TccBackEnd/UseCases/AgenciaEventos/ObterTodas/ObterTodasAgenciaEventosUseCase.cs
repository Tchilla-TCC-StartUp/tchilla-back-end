using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;

namespace TccBackEnd.UseCases.AgenciaEventos.ObterTodas;

public class ObterTodasAgenciaEventosUseCase
{
    private readonly IAgenciaEventosRepository _agenciaEventosRepository; 
    public ObterTodasAgenciaEventosUseCase(IAgenciaEventosRepository agenciaEventosRepository)
    {
        _agenciaEventosRepository = agenciaEventosRepository;
    }

    public async Task<Result<List<AgenciaEventosOutputDto>>> Executar()
    {
        return (Result<List<AgenciaEventosOutputDto>>) await _agenciaEventosRepository.ObterTodasAgenciasEventos();
    }
}