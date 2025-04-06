using TccBackEnd.UseCases.Cadastrar.Local;
using TccBackEnd.UseCases.Local.Atualizar;
using TccBackEnd.UseCases.Local.ObterPorId;

namespace TccBackEnd.Service;

public class LocalService
{
    public CadastrarLocalUseCase Cadastrar { get; }
    public AtualizarLocalUseCase Atualizar { get; }
    public ObterPorIdLocalUseCase ObterPorId { get; }
    public LocalService(
        CadastrarLocalUseCase cadastrar,
        AtualizarLocalUseCase atualizar,
        ObterPorIdLocalUseCase obterPorId
        ){
        Cadastrar = cadastrar;
        Atualizar = atualizar;
        ObterPorId = obterPorId;
    }
}