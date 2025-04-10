
using TccBackEnd.UseCases.SubCategoria.Cadastrar;
using TccBackEnd.UseCases.SubCategoria.ObterTodas;
using TccBackEnd.UseCases.SubCategoria.Remover;

namespace TccBackEnd.Service;

public class SubCategoriaService 
{
    public CadastrarSubCategoriaUseCase Cadastrar {get;}
    public ObterTodasSubCategoriaUseCase ObterTodas {get;}
    public RemoverSubCategoriaUseCase Remover {get;}
    public AtualizarSubCategoriaUseCase Atualizar {get;}
    public SubCategoriaService(
        CadastrarSubCategoriaUseCase cadastrar,
        ObterTodasSubCategoriaUseCase obterTodas,
        RemoverSubCategoriaUseCase remover,
        AtualizarSubCategoriaUseCase atualizar
    )
    {
        Cadastrar = cadastrar;  
        ObterTodas = obterTodas;
        Remover = remover;
        Atualizar = atualizar;
    }
}