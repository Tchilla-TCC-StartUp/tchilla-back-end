using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.PrestadorServico.Dtos;

namespace TccBackEnd.UseCases.PrestadorServico.Cadastrar;

public class CadastrarPrestadorUseCase
{
    private readonly IAuthRepository _repository;

    public CadastrarPrestadorUseCase(IAuthRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Executar(CadastrarPrestadorDto dto)
    {
        var prestadorServico = new Prestador()
        {
            Nif = dto.Nif
        };
        
        return (Result<string>) await _repository.CadastrarPrestador(prestadorServico);
    }
}