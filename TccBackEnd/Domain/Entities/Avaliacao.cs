namespace TccBackEnd.Domain.Entities;

public class Avaliacao
{
    public int Id { get; set; }
    public int AgendamentoId { get; set; }
    public int UsuarioId { get; set; }
    public int Nota { get; set; } // 0 a 5
    public string Comentario { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}
