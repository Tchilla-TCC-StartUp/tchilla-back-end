namespace TccBackEnd.Domain.Entities;

public class UsuarioEndereco
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public int EnderecoId { get; set; }
}