namespace TccBackEnd.Domain.Entities;

public class Agendamento
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public AgendamentoStatus Status { get; set; } = AgendamentoStatus.Pendente;
    public decimal ValorTotal { get; set; }
    public int? LocalId { get; set; }
    public int? EnderecoId { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}