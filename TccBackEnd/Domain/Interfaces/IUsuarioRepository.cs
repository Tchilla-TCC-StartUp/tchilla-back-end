using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Usuario.Dtos;

namespace TccBackEnd.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<Result<string>> Cadastrar(Usuario usuario);
    Task<Result<string>> Atualizar(Usuario usuario);
    Task<Result<UsuarioOutputDto?>> ObterPorId(int id);
    Task<Result<List<UsuarioOutputDto>?>> ObterTodos();
    Task<Result<List<UsuarioOutputDto>?>> ObterTodosPorPesquisa(string consulta);
    Task<Result<string>> DeletarUsuario(int idUsuario);
}