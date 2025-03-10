namespace TccBackEnd.Domain.Entities;

public class ComboProduto
{
    public int Id { get; set; }
    public int ComboId { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; } = 1;
}