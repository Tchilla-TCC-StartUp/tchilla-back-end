using TccBackEnd.UseCases.Auth.Logar;
using TccBackEnd.UseCases.Auth.LogOut;
using TccBackEnd.UseCases.Usuario.Cadastrar;

namespace TccBackEnd.Service;

public class AuthService
{
  public CadastrarUsuarioUseCase Cadastrar {get;}
  public LogarUseCase Logar {get;}
  public LogOutUseCase LogOut {get;}
  public AuthService(
    CadastrarUsuarioUseCase cadastrar,
    LogarUseCase logar,
    LogOutUseCase logOut
  )
  {
    Cadastrar = cadastrar;
    Logar = logar;
    LogOut = logOut;
  }
}