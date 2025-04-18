using TccBackEnd.Domain.Enums;

namespace TccBackEnd.Domain.Entities;

public class ServicoAgencia
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public int SubCategoriaId { get; set; }
    public int AgenciaId { get; set; }
    public UnidadeTipo Unidade { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}