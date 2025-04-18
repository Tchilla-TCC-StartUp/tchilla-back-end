using TccBackEnd.Domain.Enums;

namespace TccBackEnd.Domain.Entities;

public class ServicoPrestador
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public int SubCategoriaId { get; set; }
    public decimal Preco { get; set; }
    public int? PrestadorId { get; set; }
    public UnidadeTipo Unidade { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}