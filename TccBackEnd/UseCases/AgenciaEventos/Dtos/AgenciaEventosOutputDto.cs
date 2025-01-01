namespace TccBackEnd.UseCases.AgenciaEventos.Dtos;

public class AgenciaEventosOutputDto
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Nif { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Avatar  { get; set; }
    public DateTime DataNascimento { get; set; }
}