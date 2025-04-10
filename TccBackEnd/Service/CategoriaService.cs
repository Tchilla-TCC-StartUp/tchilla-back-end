using TccBackEnd.UseCases.Categoria.Cadastrar;
using TccBackEnd.UseCases.Categoria.Remover;

namespace TccBackEnd.Service;

public class CategoriaService 
{
  public CadastrarCategoriaUseCase Cadastrar {get;}
  public ObterTodasCategoriaUseCase ObterTodas {get;}
  public RemoverCategoriaUseCase Remover {get;}
  public AtualizarCategoriaUseCase Atualizar {get;}
  public CategoriaService(CadastrarCategoriaUseCase cadastrar, ObterTodasCategoriaUseCase obterTodas, RemoverCategoriaUseCase remover, AtualizarCategoriaUseCase atualizar)
  {
    Cadastrar = cadastrar; 
    ObterTodas = obterTodas;
    Remover = remover;
    Atualizar = atualizar;
  }

}