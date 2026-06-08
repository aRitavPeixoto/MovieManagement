using Microsoft.Data.Sqlite;
using MovieManagement.Domain;

namespace MovieManagement.Data
{
    public class RealizadorRepositorySQLite : IRealizadorRepository
    {
        public void AdicionarRealizador(Realizador realizador)
        {
            using var connection = DatabaseHelper.GetConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Realizadores (Nome, Pais) VALUES ($nome, $pais)";
            command.Parameters.AddWithValue("$nome", realizador.Nome);
            command.Parameters.AddWithValue("$pais", realizador.Pais);
            command.ExecuteNonQuery();
        }

        public List<Realizador> ListarRealizadores()
        {
            var realizadores = new List<Realizador>();
            using var connection = DatabaseHelper.GetConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Realizadores";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                realizadores.Add(new Realizador
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Pais = reader.GetString(2)
                });
            }
            return realizadores;
        }

        public Realizador? ProcurarRealizador(string nome)
        {
            using var connection = DatabaseHelper.GetConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Realizadores WHERE Nome = $nome";
            command.Parameters.AddWithValue("$nome", nome);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Realizador
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Pais = reader.GetString(2)
                };
            }
            return null;
        }

        public void RemoverRealizador(int id)
        {
            using var connection = DatabaseHelper.GetConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Realizadores WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id);
            command.ExecuteNonQuery();
        }
    }
}