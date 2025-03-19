using TccBackEnd.Domain.Enums;

namespace TccBackEnd.UseCases.Usuario.Dtos;

public class AtualizarUsuarioDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Nif { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public UsuarioTipo Tipo { get; set; }
    public string Foto { get; set; }
}