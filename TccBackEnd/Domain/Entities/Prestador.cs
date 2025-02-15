namespace TccBackEnd.Domain.Entities;

public class Prestador
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Nif { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Avatar  { get; set; }
    public DateTime DataNascimento { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAlteracao { get; set; }
    public DateTime DataExclusao { get; set; }
    public  int GoogleId { get; set; }
    public  int FacebookId { get; set; }
}