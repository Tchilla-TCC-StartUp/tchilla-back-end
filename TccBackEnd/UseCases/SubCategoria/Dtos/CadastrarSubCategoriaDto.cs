using TccBackEnd.Domain.Enums;

namespace TccBackEnd.UseCases.SubCategoria.Dtos;

public class CadastrarSubCategoriaDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public SubCategoriaTipo Tipo { get; set; }
    public int CategoriaId { get; set; }
}