using TccBackEnd.Domain.Enums;

public class Agencia
{
    public int Id { get; set; }
    public string Nome {get;set;}
    public string Nif { get; set; }
    public int UsuarioId { get; set; }
    public string Descricao { get; set; }
    public string Foto { get; set; }
    public bool Aprovado { get; set; } = false;
    public int? EnderecoId { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}