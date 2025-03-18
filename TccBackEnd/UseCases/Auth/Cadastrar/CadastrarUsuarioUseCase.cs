using System.Text.RegularExpressions;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Auth.Dtos;

namespace TccBackEnd.UseCases.Usuario.Cadastrar;

public class CadastrarUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public CadastrarUsuarioUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Result<string>> Executar(CadastrarUsuarioDto dto)
    {
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        string telefonePattern = @"^\d{9,15}$";

        var usuario = new Domain.Entities.Usuario()
        {
            Nome = dto.Nome,
            Telefone = (Regex.IsMatch(dto.EmailOrTelefone, telefonePattern)) ? dto.EmailOrTelefone : "",
            Email = (Regex.IsMatch(dto.EmailOrTelefone, emailPattern)) ? dto.EmailOrTelefone : "",
            Tipo = dto.Tipo,
            SenhaHash = dto.Senha
        };
        
        return (Result<string>) await _usuarioRepository.Cadastrar(usuario);
    }
}