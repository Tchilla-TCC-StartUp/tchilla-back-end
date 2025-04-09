using TccBackEnd.Domain.Entities;
using TccBackEnd.Shared.Result;

namespace TccBackEnd.Domain.Interfaces;

public interface IEnderecoRepository
{
    Task<Result<string>> CriarEndereco(Endereco endereco);
    Task<Result<string>> CriarPais(Pais pais);
    Task<Result<string>> CriarProvincia(Provincia provincia);
    Task<Result<string>> AtualizarEndereco();
    
}