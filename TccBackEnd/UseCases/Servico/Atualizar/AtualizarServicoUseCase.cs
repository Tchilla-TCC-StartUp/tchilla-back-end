using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Categoria.Dtos;
using TccBackEnd.UseCases.Search.Dtos;
using TccBackEnd.UseCases.Servico.Dtos;

namespace TccBackEnd.UseCases.Servico.Cadastrar;

    public class AtualizarServicoUseCase
    {
        private readonly ICategoriaRepository _repository;

        public AtualizarServicoUseCase(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<string>> Executar(int id, ServicoDto dto)
        {
           var novaCategoria = new Domain.Entities.Categoria
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao
            };
            return await _repository.CriarCategoria(novaCategoria);
        }
    }

