namespace TccBackEnd.Domain.Entities;

public class Local
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Capacidade { get; set; }
    public decimal PrecoHora { get; set; }
    public int? PrestadorId { get; set; }
    public int? AgenciaId { get; set; }
    public int? EnderecoId { get; set; }
    public int CategoriaId { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}