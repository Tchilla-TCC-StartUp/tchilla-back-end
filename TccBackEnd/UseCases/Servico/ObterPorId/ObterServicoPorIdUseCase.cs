using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Categoria.Dtos;
using TccBackEnd.UseCases.Search.Dtos;

namespace TccBackEnd.UseCases.Servico.ObterPorId;

    public class ObterServicoPorIdUseCase
    {
        private readonly ICategoriaRepository _repository;

        public ObterServicoPorIdUseCase(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<string>> Executar(int id)
        {
            throw new NotImplementedException("Implementar o método de obter serviço por ID.");
            //return await _repository.CriarCategoria(novaCategoria);
        }
    }

