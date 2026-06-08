using Microsoft.Data.Sqlite;

namespace MovieManagement.Data
{
    public static class DatabaseHelper
    {
        private const string ConnectionString = "Data Source=moviemanagement.db";

        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection(ConnectionString);
        }

        public static void InicializarBaseDados()
        {
            using var connection = GetConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Categorias (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Realizadores (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Pais TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Filmes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Titulo TEXT NOT NULL,
                    Ano INTEGER NOT NULL,
                    Lingua TEXT NOT NULL,
                    Classificacao INTEGER NOT NULL,
                    CategoriaId INTEGER NOT NULL,
                    RealizadorId INTEGER NOT NULL
                );
            ";
            command.ExecuteNonQuery();
        }
    }
}