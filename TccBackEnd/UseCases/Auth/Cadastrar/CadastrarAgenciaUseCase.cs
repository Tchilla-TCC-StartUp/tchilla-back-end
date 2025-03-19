// using TccBackEnd.Domain.Interfaces;
// using TccBackEnd.Shared.Result;
// using TccBackEnd.UseCases.Auth.Dtos;
// using TccBackEnd.UseCases.Cliente.Dtos;

// namespace TccBackEnd.UseCases.Cliente.Cadastrar;

// public class CadastrarAgenciaUseCase
// {
//   private readonly IAuthRepository _authRepository;

//   public CadastrarAgenciaUseCase(IAuthRepository authRepository)
//   {
//     _authRepository = authRepository;
//   }

//   public async Task<Result<string>> Executar(CadastrarAgenciaEventosDto dto)
//   {
//     var cliente = new Domain.Entities.Cliente()
//     {
//       Nome = dto.Nome,
//       Telefone = dto.Telefone,
//       Email = dto.Email,
//       Senha = dto.Senha
//     };

//     return (Result<string>)await _authRepository.CadastrarCliente(cliente);
//   }
// }