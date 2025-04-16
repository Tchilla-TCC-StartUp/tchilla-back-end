namespace TccBackEnd.UseCases.Categoria.Dtos;

public class CategoriaDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public IFormFile Foto {get;set;}
}