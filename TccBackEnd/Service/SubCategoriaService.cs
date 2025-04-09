
using TccBackEnd.UseCases.SubCategoria.Cadastrar;

namespace TccBackEnd.Service;

public class SubCategoriaService 
{
    public CadastrarSubCategoriaUseCase Cadastrar {get;}
    public SubCategoriaService(CadastrarSubCategoriaUseCase cadastrar)
    {
        Cadastrar = cadastrar;  
    }
}