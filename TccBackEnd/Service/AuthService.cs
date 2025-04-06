using TccBackEnd.UseCases.Auth.ChangePassword;
using TccBackEnd.UseCases.Auth.Logar;
using TccBackEnd.UseCases.Auth.LogOut;
using TccBackEnd.UseCases.PrestadorServico.Cadastrar;
using TccBackEnd.UseCases.Usuario.Cadastrar;

namespace TccBackEnd.Service;

public class AuthService
{
  public CadastrarUsuarioUseCase Cadastrar {get;}
  public CadastrarPrestadorUseCase CadastrarPrestador { get; set; }
  public LogarUseCase Logar {get;}
  public LogOutUseCase LogOut {get;}
  public ChangePasswordUseCase TrocarSenha{get;}
  public AuthService(
    CadastrarUsuarioUseCase cadastrar,
    CadastrarPrestadorUseCase cadastrarPrestador,
    LogarUseCase logar,
    LogOutUseCase logOut,
    ChangePasswordUseCase trocarSenha
  )
  {
    Cadastrar = cadastrar;
    CadastrarPrestador = cadastrarPrestador;
    Logar = logar;
    LogOut = logOut;
    TrocarSenha = trocarSenha;
  }
}