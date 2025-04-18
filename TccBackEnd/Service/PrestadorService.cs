using TccBackEnd.UseCases.Local.Atualizar;
using TccBackEnd.UseCases.PrestadorServico.Cadastrar;

namespace TccBackEnd.Service;

public class PrestadorService
{
    public CadastrarPrestadorUseCase Cadastrar {get;set;}
    public ObterTodosPrestadorUseCase ObterTodos {get;set;}
    public PrestadorService(
        CadastrarPrestadorUseCase cadastrar,
        ObterTodosPrestadorUseCase obterTodos
    )
    {
        Cadastrar = cadastrar;
        ObterTodos = obterTodos;
    }
}