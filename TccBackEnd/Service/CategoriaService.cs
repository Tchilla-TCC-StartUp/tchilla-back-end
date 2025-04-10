using TccBackEnd.UseCases.Categoria.Cadastrar;
using TccBackEnd.UseCases.Categoria.Remover;

namespace TccBackEnd.Service;

public class CategoriaService 
{
  public CadastrarCategoriaUseCase Cadastrar {get;}
  public ObterTodasCategoriaUseCase ObterTodas {get;}
  public RemoverCategoriaUseCase Remover {get;}
  public CategoriaService(CadastrarCategoriaUseCase cadastrar, ObterTodasCategoriaUseCase obterTodas, RemoverCategoriaUseCase remover)
  {
    Cadastrar = cadastrar; 
    ObterTodas = obterTodas;
    Remover = remover;
  }

}