using TccBackEnd.UseCases.Auth.LogOut;
using TccBackEnd.UseCases.Cliente.Cadastrar;

namespace TccBackEnd.Service;

public class AuthService
{
  public CadastrarClienteUseCase CadastrarCliente { get; }
  public CadastrarAgenciaUseCase CadastrarAgencia {get;}
  public LogarClienteUseCase LogarCliente {get;}
  public LogOutClienteUseCase LogOutCliente {get;}
  public AuthService(
    CadastrarClienteUseCase cadastrarCliente,
    LogarClienteUseCase logarCliente,
    LogOutClienteUseCase logOutCliente,
    CadastrarAgenciaUseCase cadastrarAgencia
  )
  {
    CadastrarCliente = cadastrarCliente;
    LogarCliente = logarCliente;
    LogOutCliente = logOutCliente;
    cadastrarAgencia = CadastrarAgencia;
  }
}