// using TccBackEnd.Domain.Entities;
// using TccBackEnd.Domain.Interfaces;
// using TccBackEnd.Shared.Result;
// using TccBackEnd.UseCases.AgenciaEventos.Dtos;

// namespace TccBackEnd.UseCases.AgenciaEventos.Atualizar;

// public class AtualizarAgenciaEventosUseCase
// {
//     private readonly IAgenciaEventosRepository _agenciaEventosRepository;

//     public AtualizarAgenciaEventosUseCase(IAgenciaEventosRepository agenciaEventosRepository)
//     {
//         _agenciaEventosRepository = agenciaEventosRepository;
//     }

//     public async Task<Result<string>> Executar(AtualizarAgenciaEventosDto dto)
//     {
//         var agenciaEventos = new Agencia()
//         {
//             Id = dto.Id,
//             Nome = dto.Nome,
//             Nif = dto.Nif,
//             Telefone = dto.Telefone,
//             Email = dto.Email
//         };
        
//         return (Result<string>) await _agenciaEventosRepository.AtualizarAgenciaEventos(agenciaEventos);
//     }
// }