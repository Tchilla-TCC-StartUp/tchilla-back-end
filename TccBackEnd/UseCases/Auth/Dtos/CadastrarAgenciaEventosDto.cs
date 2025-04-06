namespace TccBackEnd.UseCases.Auth.Dtos;

public class CadastrarAgenciaEventosDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Nif { get; set; }
    public int enderecoId {get; set;}
    public string Foto { get; set; }  
    public CadastrarUsuarioDto UsuarioDto{ get; set; }
}