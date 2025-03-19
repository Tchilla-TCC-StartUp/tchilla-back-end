// using TccBackEnd.Domain.Interfaces;
// using TccBackEnd.UseCases.Supervisor.Dtos;

// namespace TccBackEnd.UseCases.Supervisor.Cadastrar;

// public class CadastrarSupervisorUseCase
// {
//     private readonly ISupervisorRepository _supervisorRepository;

//     public CadastrarSupervisorUseCase(ISupervisorRepository supervisorRepository)
//     {
//         this._supervisorRepository = supervisorRepository;
//     }

//     public async Task<int> Executar(CadastrarSupervisorDto dto)
//     {
//         var supervisor = new Domain.Entities.Supervisor()
//         {
//             Nome = dto.Nome,
//             Email = dto.Email,
//             Telefone = dto.Telefone,
//             Nif = dto.Nif
//         };
        
//         return (int) await _supervisorRepository.CadastrarSupervisor(supervisor);
//     }
// }