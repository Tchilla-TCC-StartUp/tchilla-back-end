// using Npgsql;
// using TccBackEnd.Domain.Entities;
// using TccBackEnd.Domain.Interfaces;

// namespace TccBackEnd.Infra.Postgres.Repository;

// public class PrestadorServicoRepository : IPrestadorRepository
// {
//     private readonly string _connectionString;
//     public PrestadorServicoRepository(string connectionString)
//     {
//         _connectionString = connectionString;
//     }


//     public async Task<int> CadastrarPrestadorServico(Prestador prestadorServico)
//     {
//         using (var connection = new NpgsqlConnection(_connectionString))
//         {
//             await connection.OpenAsync();
//             var query = "INSERT INTO PRESTADORSERVICO(NOME, NIF, TELEFONE) VALUES(@NOME, @NIF, @TELEFONE)";
//             using (var command = new NpgsqlCommand(query, connection))
//             {
//                 command.Parameters.AddWithValue("@NOME", prestadorServico.Nome);
//                 command.Parameters.AddWithValue("@NIF", prestadorServico.Nome); 
//                 command.Parameters.AddWithValue("@TELEFONE", prestadorServico.Telefone);
                
//                 return (int) await command.ExecuteScalarAsync();
//             }
//         }
//     }

//     public async Task<UseCases.PrestadorServico?> ObterPrestadorServicoPorId(long id)
//     {
//         throw new NotImplementedException();
//     }
// }