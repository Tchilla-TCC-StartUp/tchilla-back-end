using TccBackEnd.Domain.Entities;
using TccBackEnd.Domain.Interfaces;
using TccBackEnd.Shared.Result;
using TccBackEnd.UseCases.Categoria.Dtos;

namespace TccBackEnd.UseCases.Categoria.Cadastrar;

    public class CadastrarCategoriaUseCase
    {
        private readonly ICategoriaRepository _repository;

        public CadastrarCategoriaUseCase(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<string>> Executar(CategoriaDto dto)
        {
            string filePath = Util.StorageUtil.UploadFile(dto.Foto, "Categoria");

           var novaCategoria = new Domain.Entities.Categoria
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Foto = filePath
            };
            return await _repository.CriarCategoria(novaCategoria);
        }
    }