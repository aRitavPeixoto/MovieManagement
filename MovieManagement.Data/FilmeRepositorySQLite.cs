using Microsoft.Data.Sqlite;
using MovieManagement.Domain;

namespace MovieManagement.Data
{
    public class FilmeRepositorySQLite : IFilmeRepository
    {
        public void AdicionarFilme(Filme filme)
        {
            using var connection = DatabaseHelper.GetConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO Filmes (Titulo, Ano, Lingua, Classificacao, CategoriaId, RealizadorId)
                                    VALUES ($titulo, $ano, $lingua, $classificacao, $categoriaId, $realizadorId)";
            command.Parameters.AddWithValue("$titulo", filme.Titulo);
            command.Parameters.AddWithValue("$ano", filme.Ano);
            command.Parameters.AddWithValue("$lingua", filme.Lingua);
            command.Parameters.AddWithValue("$classificacao", filme.Classificacao);
            command.Parameters.AddWithValue("$categoriaId", filme.CategoriaId);
            command.Parameters.AddWithValue("$realizadorId", filme.RealizadorId);
            command.ExecuteNonQuery();
        }

        public List<Filme> ListarFilmes()
        {
            var filmes = new List<Filme>();
            using var connection = DatabaseHelper.GetConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Filmes";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                filmes.Add(new Filme
                {
                    Id = reader.GetInt32(0),
                    Titulo = reader.GetString(1),
                    Ano = reader.GetInt32(2),
                    Lingua = reader.GetString(3),
                    Classificacao = reader.GetInt32(4),
                    CategoriaId = reader.GetInt32(5),
                    RealizadorId = reader.GetInt32(6)
                });
            }
            return filmes;
        }

        public Filme? ProcurarPorTitulo(string titulo)
        {
            using var connection = DatabaseHelper.GetConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Filmes WHERE Titulo = $titulo";
            command.Parameters.AddWithValue("$titulo", titulo);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Filme
                {
                    Id = reader.GetInt32(0),
                    Titulo = reader.GetString(1),
                    Ano = reader.GetInt32(2),
                    Lingua = reader.GetString(3),
                    Classificacao = reader.GetInt32(4),
                    CategoriaId = reader.GetInt32(5),
                    RealizadorId = reader.GetInt32(6)
                };
            }
            return null;
        }

        public void RemoverFilme(int id)
        {
            using var connection = DatabaseHelper.GetConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Filmes WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id);
            command.ExecuteNonQuery();
        }
    }
}