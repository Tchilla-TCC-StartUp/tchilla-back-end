using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Categoria.Dtos;

namespace TccBackEnd.UseCases.Categoria.Cadastrar;

    public class AtualizarCategoriaUseCase
    {
        private readonly ICategoriaRepository _repository;

        public AtualizarCategoriaUseCase(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<string>> Executar(int id, CategoriaDto dto)
        {
           var novaCategoria = new Domain.Entities.Categoria
            {
              Id = id,
              Nome = dto.Nome,
              Descricao = dto.Descricao
            };
            return await _repository.AtualizarCategoria(novaCategoria);
        }
    }