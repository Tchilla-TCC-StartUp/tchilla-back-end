using TccBackEnd.Domain.Enums;
using TccBackEnd.UseCases.Auth.Dtos;

namespace TccBackEnd.UseCases.PrestadorServico.Dtos;

public class CadastrarPrestadorDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Nif { get; set; }
    public int enderecoId {get; set;}
    public PrestadorTipo Tipo { get; set; }
    public string Foto { get; set; }  
    public CadastrarUsuarioDto UsuarioDto{ get; set;  }
}