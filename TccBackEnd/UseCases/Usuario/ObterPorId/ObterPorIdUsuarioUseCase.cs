using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Usuario.Dtos;

namespace TccBackEnd.UseCases.Usuario.ObterPorId;

 public class ObterPorIdUsuarioUseCase
 {
     private readonly IUsuarioRepository _usuarioRepository;
     public ObterPorIdUsuarioUseCase(IUsuarioRepository usuarioRepository)
     {
         _usuarioRepository = usuarioRepository;
     }

     public async Task<Result<UsuarioOutputDto?>> Executar(long id)
     {
         return (Result<UsuarioOutputDto?>) await _usuarioRepository.ObterPorId(id);
     }
 }
