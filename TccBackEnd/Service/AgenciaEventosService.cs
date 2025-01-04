using TccBackEnd.UseCases.AgenciaEventos.Atualizar;
using TccBackEnd.UseCases.AgenciaEventos.Cadastrar;
using TccBackEnd.UseCases.AgenciaEventos.ObterPorId;
using TccBackEnd.UseCases.AgenciaEventos.ObterTodas;
using TccBackEnd.UseCases.AgenciaEventos.ObterTodasPorPesquisa;

namespace TccBackEnd.Service;

public class AgenciaEventosService
{
    public CadastrarAgenciaEventosUseCase Cadastrar { get; }
    public AtualizarAgenciaEventosUseCase Atualizar { get; }
    public ObterPorIdAgenciaEventosUseCase ObterPorId { get; }
    public ObterTodasAgenciaEventosUseCase ObterTodas { get; }
    public ObterTodasPorPesquisaAgenciaEventosUseCase ObterTodasPorPesquisa { get; }

    public AgenciaEventosService(
        CadastrarAgenciaEventosUseCase cadastrar,
        AtualizarAgenciaEventosUseCase atualizar,
        ObterPorIdAgenciaEventosUseCase obterPorId,
        ObterTodasAgenciaEventosUseCase obterTodas,
        ObterTodasPorPesquisaAgenciaEventosUseCase obterTodasPorPesquisa)
    {
        Cadastrar = cadastrar;
        Atualizar = atualizar;
        ObterPorId = obterPorId;
        ObterTodas = obterTodas;
        ObterTodasPorPesquisa = obterTodasPorPesquisa;
    }
}
