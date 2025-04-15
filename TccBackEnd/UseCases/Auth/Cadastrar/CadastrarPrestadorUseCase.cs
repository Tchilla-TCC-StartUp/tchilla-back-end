using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Enums;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.PrestadorServico.Dtos;

namespace TccBackEnd.UseCases.PrestadorServico.Cadastrar;

public class CadastrarPrestadorUseCase
{
    private readonly IAuthRepository _repository;

    public CadastrarPrestadorUseCase(IAuthRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Executar(CadastrarPrestadorDto dto)
    {

        var novoUsuario = new TccBackEnd.Domain.Entities.Usuario()
        {
            Nome = dto.UsuarioDto.Nome,
            Email = dto.UsuarioDto.Email,
            Telefone = dto.UsuarioDto.Telefone,
            Foto = "",
            Tipo = UsuarioTipo.Prestador,
            SenhaHash = dto.UsuarioDto.Senha
        };

        var registrarUsuario = await _repository.CadastrarUsuario(novoUsuario);
        if (!registrarUsuario.IsSuccess || string.IsNullOrEmpty(registrarUsuario.Data))
        {
            return Result<string>.Error("Erro ao cadastrar usuário." );
        }

        var novoPrestador = new Prestador()
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            Foto = dto.Foto,
            Nif = dto.Nif,
            Tipo = dto.Tipo,
            UsuarioId = int.Parse(registrarUsuario.Data)
        };
        
        return (registrarUsuario.IsSuccess) 
        ?  (Result<string>) await _repository.CadastrarPrestador(novoPrestador)
        : Result<string>.Error("Não foi possível realizar está operação");
    }
}