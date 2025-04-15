using TccBackEnd.Domain.Enums;

namespace TccBackEnd.UseCases.Servico.Dtos;

public class CadastrarServicoDto
{
  public string Nome { get; set; }
  public string? Descricao { get; set; }
  public int subCategoriaId { get; set; }
  public decimal Preco { get; set; }
  public int OwnerId { get; set; }
  public UnidadeTipo Unidade { get; set; }
}