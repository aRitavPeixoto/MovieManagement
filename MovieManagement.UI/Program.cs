using MovieManagement.Business;
using MovieManagement.Data;
using MovieManagement.Domain;

var repository = new FilmeRepositoryMemoria();
var service = new FilmeService(repository);

bool sair = false;

while (!sair)
{
    Console.WriteLine("\n=== MOVIE MANAGEMENT ===");
    Console.WriteLine();
    Console.WriteLine("1. Adicionar Filme");
    Console.WriteLine("2. Listar Filmes");
    Console.WriteLine("3. Procurar Filme por Título");
    Console.WriteLine("4. Remover Filme");
    Console.WriteLine("0. Sair");
    Console.WriteLine();
    Console.Write("Opção: ");

    string opcao = Console.ReadLine() ?? "";

    switch (opcao)
    {
        case "1":
            Console.Write("Título: ");
            string titulo = Console.ReadLine() ?? "";
            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Língua: ");
            string lingua = Console.ReadLine() ?? "";
            Console.Write("Classificação (0-5): ");
            int classificacao = int.Parse(Console.ReadLine() ?? "0");

            var filme = new Filme
            {
                Titulo = titulo,
                Ano = ano,
                Lingua = lingua,
                Classificacao = classificacao
            };

            try
            {
                service.AdicionarFilme(filme);
                Console.WriteLine("Filme adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            break;

        case "2":
            var filmes = service.ListarFilmes();
            if (filmes.Count == 0)
                Console.WriteLine("Nenhum filme encontrado.");
            else
                foreach (var f in filmes)
                    Console.WriteLine($"[{f.Id}] {f.Titulo} ({f.Ano}) - {f.Lingua} - {f.Classificacao}/5");
            break;

        case "3":
            Console.Write("Título: ");
            var resultado = service.ProcurarPorTitulo(Console.ReadLine() ?? "");
            if (resultado == null)
                Console.WriteLine("Filme não encontrado.");
            else
                Console.WriteLine($"[{resultado.Id}] {resultado.Titulo} ({resultado.Ano}) - {resultado.Lingua} - {resultado.Classificacao}/5");
            break;

        case "4":
            Console.Write("ID do filme a remover: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            service.RemoverFilme(id);
            Console.WriteLine("Filme removido!");
            break;

        case "0":
            sair = true;
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}