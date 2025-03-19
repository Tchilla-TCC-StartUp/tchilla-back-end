namespace TccBackEnd.Domain.Entities;

public class ComboServico
{
    public int Id { get; set; }
    public int ComboId { get; set; }
    public int ServicoId { get; set; }
    public int Quantidade { get; set; } = 1;
}