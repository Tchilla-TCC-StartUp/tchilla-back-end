using TccBackEnd.UseCases.AgenciaEventos.ObterTodasPorPesquisa;
using TccBackEnd.UseCases.Usuario.ObterPorId;
using TccBackEnd.UseCases.Usuario.Atualizar;
using TccBackEnd.UseCases.Usuario.Cadastrar;
using TccBackEnd.UseCases.Usuario.ObterTodos;
using TccBackEnd.UseCases.Usuario.ObterTodosPorPesquisa;
using TccBackEnd.UseCases.Usuario.Deletar;

namespace TccBackEnd.Service;

public class UsuarioService
{
    public AtualizarUsuarioUseCase Atualizar { get; }
    public ObterPorIdUsuarioUseCase ObterPorId { get; }
    public ObterTodosUsuarioUseCase ObterTodos { get; }
    public DeletarUsuarioUseCase Deletar {get;}
    public ObterTodosPorPesquisaUsuarioUseCase ObterTodosPorPesquisa { get; }
    public UsuarioService(        
        AtualizarUsuarioUseCase atualizar,
        ObterPorIdUsuarioUseCase obterPorId,
        ObterTodosUsuarioUseCase obterTodos,
        ObterTodosPorPesquisaUsuarioUseCase obterTodosPorPesquisa,
        DeletarUsuarioUseCase deletar
    )
    { 
        Atualizar = atualizar;
        ObterPorId = obterPorId;
        ObterTodos = obterTodos;
        ObterTodosPorPesquisa = obterTodosPorPesquisa;
        Deletar = deletar;
    }
}