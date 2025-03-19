namespace TccBackEnd.UseCases.Usuario.Dtos;

public class UsuarioOutputDto
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Nif { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Avatar  { get; set; }
}