namespace TccBackEnd.Domain.Entities;

public class Endereco
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string Nome { get; set; }
    public string Provincia_estado { get; set; }
    public string Cumuna_destrito { get; set; }
    public string Bairro { get; set; }
    public int rua { get; set; }
    public int numero { get; set; }
    //public string criado { get; set; }
    //public string atualizado { get; set; }
    public virtual Cliente? IdClienteNavgation { get; set; }
}