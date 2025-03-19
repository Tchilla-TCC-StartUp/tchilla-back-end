// using System.Data;
// using Npgsql;
// using TccBackEnd.Domain.Entities;

// namespace TccBackEnd.Infra.Postgres.Repository;

// public class SupervisorRepository
// {
//     private readonly string _connectionString;
//     public SupervisorRepository(string connectionString)
//     {
//         _connectionString = connectionString;
//     }

//     public async Task<int> Cadastrar(Supervisor supervisor)
//     {
//         using (var connection = new NpgsqlConnection(_connectionString))
//         {
//             await connection.OpenAsync();
//             var query = "INSERT INTO SUPERVISOR(NOME, EMAIL, TELEFONE) VALUES (@nome, @email, @telefone)";
//             using (var command = new NpgsqlCommand(query, connection))
//             {
//                 command.Parameters.AddWithValue("@nome", supervisor.Nome);
//                 command.Parameters.AddWithValue("@email", supervisor.Email);
//                 command.Parameters.AddWithValue("@telefone", supervisor.Telefone);

//                 return (int)await command.ExecuteScalarAsync();
//             }
//         }
//     }

//     public async Task<Supervisor?> ObterSupervisorPorId(long id)
//     {
//         using (var connection = new NpgsqlConnection(_connectionString))
//         {
//             await connection.OpenAsync();
//             var query = "SELECT * FROM SUPERVISOR WHERE id = @id";
//             using (var command = new NpgsqlCommand(query, connection))
//             {
//                 command.Parameters.AddWithValue("@id", id);
//                 using (var reader = await command.ExecuteReaderAsync())
//                 {
//                     if (await reader.ReadAsync())
//                     {
//                         return new Supervisor()
//                         {
//                             Id = reader.GetInt64(0),
//                             Nome = reader.GetString(1),
//                             Email = reader.GetString(2),
//                             Telefone = reader.GetString(3) 
//                         };
//                     }
//                 }
//             }

//             return null;
//         }
//     }
// }