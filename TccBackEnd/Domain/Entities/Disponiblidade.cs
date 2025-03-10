namespace TccBackEnd.Domain.Entities;
public class Disponibilidade
{
    public int Id { get; set; }
    public DisponibilidadeTipo Tipo { get; set; }
    public int ReferenciaId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public decimal Preco { get; set; }
    public int? QuantidadeDisponivel { get; set; }
    public DisponibilidadeStatus Status { get; set; } = DisponibilidadeStatus.Disponivel;
}
