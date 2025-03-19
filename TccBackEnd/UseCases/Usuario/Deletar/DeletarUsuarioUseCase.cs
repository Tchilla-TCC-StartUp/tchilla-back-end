using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.UseCases.Usuario.Deletar;

public class DeletarUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    public DeletarUsuarioUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Result<string>> Executar(int idUsuario)
    {
        return (Result<string>) await _usuarioRepository.DeletarUsuario(idUsuario);
    }
}