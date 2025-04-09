using TccBackEnd.Domain.Enums;

namespace TccBackEnd.Domain.Entities
{
    public class SubCategoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public SubCategoriaTipo Tipo { get; set; }
        public int CategoriaId { get; set; }
    }
}