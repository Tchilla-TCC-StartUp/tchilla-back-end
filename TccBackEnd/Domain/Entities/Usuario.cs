using TccBackEnd.Domain.Enums;

namespace TccBackEnd.Domain.Entities;
public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string SenhaHash { get; set; }
    public string Telefone { get; set; }
    public UsuarioTipo Tipo { get; set; }
    public string Foto { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}