using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;
using TccBackEnd.UseCases.Auth.Dtos;

namespace TccBackEnd.UseCases.AgenciaEventos.ObterTodasPorPesquisa;

public class ObterTodasPorPesquisaAgenciaEventosUseCase
{
    private readonly IAgenciaEventosRepository _agenciaEventosRepository;
    public ObterTodasPorPesquisaAgenciaEventosUseCase(IAgenciaEventosRepository agenciaEventosRepository)
    {
        _agenciaEventosRepository = agenciaEventosRepository;
    }

    public async Task<Result<List<AgenciaEventosOutputDto>?>> Executar(string consulta)
    {
        return await _agenciaEventosRepository.ObterTodasAgenciasEventosPorPesquisa(consulta);
    }
}