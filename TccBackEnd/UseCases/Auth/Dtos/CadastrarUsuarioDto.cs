using TccBackEnd.Domain.Enums;

namespace TccBackEnd.UseCases.Auth.Dtos;

public class CadastrarUsuarioDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone {get;set;}
    public string Senha { get; set; }
    public UsuarioTipo Tipo { get; set; }

}