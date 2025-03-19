using TccBackEnd.Domain.Enums;

namespace TccBackEnd.UseCases.Search.Dtos;

public class SearchLocalInputDto
{
  public string LocalEvento {get;set;}
  public DateTime DataEvento {get;set;}
  public TipoEvento Tipo {get;set;}
  public int NumeroConvidados {get;set;}
}