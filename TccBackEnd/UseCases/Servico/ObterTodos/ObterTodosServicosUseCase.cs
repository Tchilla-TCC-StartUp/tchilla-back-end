using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Categoria.Dtos;
using TccBackEnd.UseCases.Search.Dtos;
using TccBackEnd.UseCases.Servico.Dtos;

namespace TccBackEnd.UseCases.Servico.ObterTodos;

    public class ObterTodosServicoUseCase
    {
        private readonly IServicoRepository _repository;

        public ObterTodosServicoUseCase(IServicoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<ServicoOutPutDto>>> Executar()
        {

            return await _repository.ObterTodosServicos();
        }
    }

