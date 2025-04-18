using TccBackEnd.UseCases.Usuario.Dtos;

namespace TccBackEnd.UseCases.PrestadorServico.Dtos;

public class PrestadorOutputDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Nif { get; set; }
    public UsuarioOutputDto Usuario { get; set; }
    public string Telefone {get;set;}
    public string Email {get;set;}
    public string Descricao { get; set; }
    public string Tipo { get; set; }
    public string Foto { get; set; }    
    public int EnderecoId { get; set; }
}