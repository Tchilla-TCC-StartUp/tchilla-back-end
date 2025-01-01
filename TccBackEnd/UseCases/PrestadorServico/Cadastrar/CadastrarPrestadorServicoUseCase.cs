using TccBackEnd.Domain.Interfaces;
using TccBackEnd.UseCases.PrestadorServico.Dtos;

namespace TccBackEnd.UseCases.PrestadorServico.Cadastrar;

public class CadastrarPrestadorServicoUseCase
{
    private readonly IPrestadorServicoRepository _prestadorServicoRepository;

    public CadastrarPrestadorServicoUseCase(IPrestadorServicoRepository prestadorServicoRepository)
    {
        _prestadorServicoRepository = prestadorServicoRepository;
    }

    public async Task<int> Executar(CadastrarPrestadorServicoDto dto)
    {
        var prestadorServico = new Domain.Entities.PrestadorServico()
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Telefone = dto.Telefone,
            Nif = dto.Nif
        };
        
        return (int) await _prestadorServicoRepository.CadastrarPrestadorServico(prestadorServico);
    }
}