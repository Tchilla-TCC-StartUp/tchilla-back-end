 using TccBackEnd.Domain.Interfaces;
 using TccBackEnd.Shared.Result;
 using TccBackEnd.UseCases.Usuario.Dtos;

 namespace TccBackEnd.UseCases.Usuario.ObterTodosPorPesquisa;

 public class ObterTodosPorPesquisaUsuarioUseCase
 {
     private readonly IUsuarioRepository _usuarioRepository;

     public ObterTodosPorPesquisaUsuarioUseCase(IUsuarioRepository usuarioRepository)
     {
         _usuarioRepository = usuarioRepository;
     }

     public async Task<Result<List<UsuarioOutputDto>?>> Executar(string consulta)
     {
         return (Result<List<UsuarioOutputDto>?>) await _usuarioRepository.ObterTodos();
     }
 }