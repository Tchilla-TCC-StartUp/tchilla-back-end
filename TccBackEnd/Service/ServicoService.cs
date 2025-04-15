using TccBackEnd.UseCases.Servico.Cadastrar;
using TccBackEnd.UseCases.Servico.ObterPorId;
using TccBackEnd.UseCases.Servico.ObterTodos;

namespace TccBackEnd.Service;

public class ServicoService
{
    public readonly CadastrarServicoUseCase Cadastrar;
    public readonly AtualizarServicoUseCase Atualizar;
    public readonly RemoverServicoUseCase Remover;
    public readonly ObterTodosServicoUseCase ObterTodas;
    public readonly ObterServicoPorIdUseCase ObterPorId;

    public ServicoService(
        CadastrarServicoUseCase cadastrar,
        AtualizarServicoUseCase atualizar,
        RemoverServicoUseCase remover,
        ObterTodosServicoUseCase obterTodos,
        ObterServicoPorIdUseCase obterPorId)
    {
        Cadastrar = cadastrar;
        Atualizar = atualizar;
        Remover = remover;
        ObterTodas = obterTodos;
        ObterPorId = obterPorId;
    }
}