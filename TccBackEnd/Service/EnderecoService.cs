using TccBackEnd.UseCases.Endereco.Cadastrar;

namespace TccBackEnd.Service;

public class EnderecoService
{
    public CadastrarEnderecoUseCase Cadastrar { get; }
    public CadastrarPaisUseCase CadastrarPais { get; }
    public CadastrarProvinciaUseCase CadastrarProvincia { get; }
    public EnderecoService(
        CadastrarEnderecoUseCase cadastrar,
        CadastrarPaisUseCase cadastrarPais,
        CadastrarProvinciaUseCase cadastrarProvincia
        )
    {
        Cadastrar = cadastrar;
        CadastrarPais = CadastrarPais;
        CadastrarProvincia = cadastrarProvincia;
    }
    
}