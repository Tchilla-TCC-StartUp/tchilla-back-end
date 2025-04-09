namespace TccBackEnd.UseCases.Local.Dtos;

public class CadastrarLocalDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Capacidade { get; set; }
    public decimal PrecoHora { get; set; }
    public int? PrestadorId { get; set; }
    public int? AgenciaId { get; set; }
    public int? EnderecoId { get; set; }
    public int CategoriaId { get; set; }
}