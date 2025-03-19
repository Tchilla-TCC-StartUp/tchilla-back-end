namespace TccBackEnd.Domain.Entities;

public class Endereco
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public string Rua { get; set; }
    public string Cidade { get; set; }
    public int? EstadoProvinciaId { get; set; }
    public string Cep { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public int? PaisId { get; set; }
}