using Microsoft.Data.Sqlite;
using MovieManagement.Domain;

namespace MovieManagement.Data
{
    public class CategoriaRepositorySQLite : ICategoriaRepository
    {
        public void AdicionarCategoria(Categoria categoria)
        {
            using var connection = DatabaseHelper.GetConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Categorias (Nome) VALUES ($nome)";
            command.Parameters.AddWithValue("$nome", categoria.Nome);
            command.ExecuteNonQuery();
        }


        public List<Categoria> ListarCategorias()
        {
            var categorias = new List<Categoria>();
            using var connection = DatabaseHelper.GetConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Categorias";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                categorias.Add(new Categoria
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                });
            }
            return categorias;
        }


        public Categoria? ProcurarPorCategoria(string nome)
        {
            using var connection = DatabaseHelper.GetConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Categorias WHERE Nome = $nome";
            command.Parameters.AddWithValue("$nome", nome);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Categoria
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                };
            }
            return null;
        }


        public void RemoverCategoria(int id)
        {
            using var connection = DatabaseHelper.GetConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Categorias WHERE Id = $id";
            command.Parameters.AddWithValue("$id", id);
            command.ExecuteNonQuery();
        }
    }
}