using TccBackEnd.UseCases.Cliente.Cadastrar;

namespace TccBackEnd.Service;

public class ClienteService
{
    public CadastrarClienteUseCase Cadastrar { get; }

    public ClienteService(
        CadastrarClienteUseCase cadastrar
        )
    {
        Cadastrar = cadastrar;
    }
}