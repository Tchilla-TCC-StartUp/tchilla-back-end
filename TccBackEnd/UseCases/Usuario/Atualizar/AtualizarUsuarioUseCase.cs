 using TccBackEnd.Domain.Interfaces;
 using TccBackEnd.Shared.Result;
 using TccBackEnd.UseCases.Auth.Dtos;
 using TccBackEnd.UseCases.Usuario.Dtos;

 namespace TccBackEnd.UseCases.Usuario.Atualizar;

 public class AtualizarUsuarioUseCase
 {
     private readonly IUsuarioRepository _usuarioRepository;
     public AtualizarUsuarioUseCase(IUsuarioRepository usuarioRepository)
     {
         _usuarioRepository = usuarioRepository;
     }

     public async Task<Result<string>> Executar(AtualizarUsuarioDto dto)
     {
         var usuario = new Domain.Entities.Usuario()
         {
             Id = dto.Id,
             Nome = dto.Nome,
             Telefone = dto.Telefone,
             Email = dto.Email,
             Foto = dto.Foto,
             Tipo = dto.Tipo
         };
        
         return (Result<string>) await _usuarioRepository.Atualizar(usuario);
    }
}