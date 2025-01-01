using TccBackEnd.Domain.Interfaces;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;

namespace TccBackEnd.UseCases.AgenciaEventos.Atualizar;

public class AtualizarAgenciaEventosUseCase
{
    private readonly IAgenciaEventosRepository _agenciaEventosRepository;

    public AtualizarAgenciaEventosUseCase(IAgenciaEventosRepository agenciaEventosRepository)
    {
        _agenciaEventosRepository = agenciaEventosRepository;
    }

    public async Task<bool> Executar(AtualizarAgenciaEventosDto dto)
    {
        var agenciaEventos = new Domain.Entities.AgenciaEventos()
        {
            Nome = dto.Nome,
            Nif = dto.Nif,
            Telefone = dto.Telefone,
            Email = dto.Email
        };
        
        return (bool) await _agenciaEventosRepository.AtualizarAgenciaEventos(agenciaEventos);
    }
}