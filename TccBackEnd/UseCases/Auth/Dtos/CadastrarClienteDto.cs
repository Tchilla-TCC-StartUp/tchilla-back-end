namespace TccBackEnd.UseCases.Cliente.Dtos;

public class CadastrarClienteDto
{
    public string Nome { get; set; }
    public string Nif { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Localizacao  { get; set; }
}