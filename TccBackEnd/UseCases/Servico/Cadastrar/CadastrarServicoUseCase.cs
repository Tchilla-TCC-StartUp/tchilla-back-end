using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Categoria.Dtos;
using TccBackEnd.UseCases.Search.Dtos;
using TccBackEnd.UseCases.Servico.Dtos;

namespace TccBackEnd.UseCases.Servico.Cadastrar;

public class CadastrarServicoUseCase
{
    private readonly IServicoRepository _repository;

    public CadastrarServicoUseCase(IServicoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Executar(string tipo, CadastrarServicoDto dto)
    {
        if (string.IsNullOrEmpty(tipo))
            return Result<string>.Error("Tipo de usuário inválido");
        try
        {
            if (tipo == "Prestador")
            {
                var servicoPrestador = new ServicoPrestador
                {
                    Nome = dto.Nome,
                    Descricao = dto.Descricao,
                    SubCategoriaId = dto.subCategoriaId,
                    Preco = dto.Preco,
                    Unidade = dto.Unidade,
                    PrestadorId = dto.OwnerId
                };
                return await _repository.CriarServicoPrestador(servicoPrestador);
            }
            else if (tipo == "Agencia")
            {
                var servicoAgencia = new ServicoAgencia
                {
                    Nome = dto.Nome,
                    Descricao = dto.Descricao,
                    SubCategoriaId = dto.subCategoriaId,
                    Preco = dto.Preco,
                    Unidade = dto.Unidade,
                    AgenciaId = dto.OwnerId
                };

                return await _repository.CriarServicoAgencia(servicoAgencia);
            }
            return Result<string>.Error("Não foi possível cadastrar o serviço");
        }
        catch (Exception)
        {
            return Result<string>.Error("Erro ao cadastrar serviço");
        }

    }

}

