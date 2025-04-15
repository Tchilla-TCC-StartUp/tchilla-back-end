using TccBackEnd.Domain.Enums;

namespace TccBackEnd.UseCases.Servico.Dtos;

public class ServicoOutPutDto
{
  public int Id { get; set; }
  public string Nome { get; set; }
  public string? Descricao { get; set; }
  public int subCategoriaId { get; set; }
  public decimal Preco { get; set; }
  public int? PrestadorId { get; set; }
  public UnidadeTipo Unidade { get; set; }
  public List<ServicoPrestadorMidiaDto> Midias { get; set; } = new List<ServicoPrestadorMidiaDto>();
  public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}