using TccBackEnd.UseCases.AgenciaEventos.ObterTodasPorPesquisa;
using TccBackEnd.UseCases.Cliente.Atualizar;
using TccBackEnd.UseCases.Cliente.Cadastrar;
using TccBackEnd.UseCases.Cliente.ObterPorId;
using TccBackEnd.UseCases.Cliente.ObterTodos;
using TccBackEnd.UseCases.Cliente.ObterTodosPorPesquisa;

namespace TccBackEnd.Service;

public class ClienteService
{
    public CadastrarClienteUseCase Cadastrar { get; }
    public AtualizarClienteUseCase Atualizar { get; }
    public ObterPorIdClienteUseCase ObterPorId { get; }
    public ObterTodosClienteUseCase ObterTodos { get; }
    public ObterTodosPorPesquisaClienteUseCase ObterTodosPorPesquisa { get; }
    public ClienteService(
        CadastrarClienteUseCase cadastrar,
        AtualizarClienteUseCase atualizar,
        ObterPorIdClienteUseCase obterPorId,
        ObterTodosClienteUseCase obterTodos,
        ObterTodosPorPesquisaClienteUseCase obterTodosPorPesquisa
        )
    {
        Cadastrar = cadastrar;
        Atualizar = atualizar;
        ObterPorId = obterPorId;
        ObterTodos = obterTodos;
        ObterTodosPorPesquisa = obterTodosPorPesquisa;
    }
}