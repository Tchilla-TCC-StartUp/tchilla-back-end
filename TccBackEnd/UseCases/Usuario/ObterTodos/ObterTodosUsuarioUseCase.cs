using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Usuario.Dtos;

namespace TccBackEnd.UseCases.Usuario.ObterTodos;

public class ObterTodosUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ObterTodosUsuarioUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Result<List<UsuarioOutputDto>?>> Executar()
    {
        return (Result<List<UsuarioOutputDto>?>) await _usuarioRepository.ObterTodos();
    }
}