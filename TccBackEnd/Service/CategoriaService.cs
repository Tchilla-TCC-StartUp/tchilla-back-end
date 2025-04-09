using TccBackEnd.UseCases.Categoria.Cadastrar;

namespace TccBackEnd.Service;

public class CategoriaService 
{
  public CadastrarCategoriaUseCase Cadastrar {get;}
  public CategoriaService(CadastrarCategoriaUseCase cadastrar)
  {
    Cadastrar = cadastrar;  
  }
}