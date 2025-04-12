using TccBackEnd.Domain.Enums;

namespace TccBackEnd.Domain.Entities;

public class ServicoPrestadorMidia
{
    public int Id { get; set; }
    public string Url { get; set; }
    public TipoMedia Tipo { get; set; } 
}