using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Auth.Dtos;
namespace TccBackEnd.Domain.Interfaces;

public interface IAuthRepository
{
  Task<Result<string>> Logar(LogarCredenciaisDto dto);
  Task<Result<string>> CadastrarUsuario(Usuario usuario);
  Task<Result<string>> CadastrarPrestador(Prestador prestadorServico);
  Task<Result<string>> LogOut(int id);
  Task<Result<string>> ForgotPassword(string email);
  Task<Result<string>> VerificarEmail(string token);
  Task<Result<string>> TrocarSenha(int userId, string newPassword);

}
