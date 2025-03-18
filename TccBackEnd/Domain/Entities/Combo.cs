using TccBackEnd.Domain.Enums;

namespace TccBackEnd.Domain.Entities;

public class Combo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int? PrestadorId { get; set; }
    public int? AgenciaId { get; set; }
    public decimal Preco { get; set; }
    public string Foto { get; set; }
    public ComboStatus Status { get; set; } = ComboStatus.Ativo;
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}