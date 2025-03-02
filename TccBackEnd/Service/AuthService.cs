using TccBackEnd.UseCases.Cliente.Cadastrar;

namespace TccBackEnd.Service;

public class AuthService
{
  public CadastrarClienteUseCase CadastrarCliente { get; }
  public LogarClienteUseCase LogarCliente {get;set;}
}