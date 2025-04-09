using TccBackEnd.UseCases.Categoria.Cadastrar;

namespace TccBackEnd.Service;

public class CategoriaService 
{
  public CadastrarCategoriaUseCase Cadastrar {get;}
  public ObterTodasCategoriaUseCase ObterTodas {get;}
  public CategoriaService(CadastrarCategoriaUseCase cadastrar, ObterTodasCategoriaUseCase obterTodas)
  {
    Cadastrar = cadastrar; 
    ObterTodas = obterTodas;
  }
}