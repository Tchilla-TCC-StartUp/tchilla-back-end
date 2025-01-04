using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.AgenciaEventos.Dtos;

namespace TccBackEnd.UseCases.AgenciaEventos.Cadastrar;

public class CadastrarAgenciaEventosUseCase
{
    private readonly IAgenciaEventosRepository _agenciaEventosRepository;

    public CadastrarAgenciaEventosUseCase(IAgenciaEventosRepository agenciaEventosRepository)
    {
        _agenciaEventosRepository = agenciaEventosRepository;
    }

    public async Task<Result<string>> Executar(CadastrarAgenciaEventosDto dto)
    {
        var agenciaEventos = new Domain.Entities.AgenciaEventos()
        {
            Nome = dto.Nome,
            Nif = dto.Nif,
            Telefone = dto.Telefone,
            Email = dto.Email
        };
        return (Result<string>) await _agenciaEventosRepository.CadastrarAgenciaEventos(agenciaEventos);
    }
}