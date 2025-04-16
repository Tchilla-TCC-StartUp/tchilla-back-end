using TccBackEnd.Domain.Enums;

namespace TccBackEnd.Domain.Entities;

public class Prestador
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Nif { get; set; }
    public int UsuarioId { get; set; }
    public string Telefone {get;set;}
    public string Descricao { get; set; }
    public PrestadorTipo Tipo { get; set; }
    public string Foto { get; set; }    
    public bool Aprovado { get; set; } = false;
    public int EnderecoId { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}