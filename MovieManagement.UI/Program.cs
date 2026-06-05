using MovieManagement.Business;
using MovieManagement.Data;
using MovieManagement.Domain;

var filmeRepository = new FilmeRepositoryMemoria();
var filmeService = new FilmeService(filmeRepository);

var categoriaRepository = new CategoriaRepositoryMemoria();
var categoriaService = new CategoriaService(categoriaRepository);

var realizadorRepository = new RealizadorRepositoryMemoria();
var realizadorService = new RealizadorService(realizadorRepository);

bool sair = false;

while (!sair)
{
    Console.WriteLine("\n=== MOVIE MANAGEMENT ===");
    Console.WriteLine("1. Filmes");
    Console.WriteLine("2. Categorias");
    Console.WriteLine("3. Realizadores");
    Console.WriteLine("0. Sair");
    Console.Write("Opção: ");

    string opcao = Console.ReadLine() ?? "";

    switch (opcao)
    {
        case "1":
            GerirFilmes(filmeService);
            break;
        case "2":
            GerirCategorias(categoriaService);
            break;
        case "3":
            GerirRealizadores(realizadorService);
            break;
        case "0":
            sair = true;
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}

void GerirFilmes(FilmeService service)
{
    Console.WriteLine("\n--- FILMES ---");
    Console.WriteLine("1. Adicionar");
    Console.WriteLine("2. Listar");
    Console.WriteLine("3. Procurar por título");
    Console.WriteLine("4. Remover");
    Console.Write("Opção: ");

    switch (Console.ReadLine() ?? "")
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
            try
            {
                service.AdicionarFilme(new Filme { Titulo = titulo, Ano = ano, Lingua = lingua, Classificacao = classificacao });
                Console.WriteLine("Filme adicionado!");
            }
            catch (Exception ex) { Console.WriteLine($"Erro: {ex.Message}"); }
            break;
        case "2":
            var filmes = service.ListarFilmes();
            if (filmes.Count == 0) Console.WriteLine("Nenhum filme.");
            else foreach (var f in filmes)
                Console.WriteLine($"[{f.Id}] {f.Titulo} ({f.Ano}) - {f.Lingua} - {f.Classificacao}/5");
            break;
        case "3":
            Console.Write("Título: ");
            var filme = service.ProcurarPorTitulo(Console.ReadLine() ?? "");
            if (filme == null) Console.WriteLine("Não encontrado.");
            else Console.WriteLine($"[{filme.Id}] {filme.Titulo} ({filme.Ano})");
            break;
        case "4":
            Console.Write("ID: ");
            service.RemoverFilme(int.Parse(Console.ReadLine() ?? "0"));
            Console.WriteLine("Removido!");
            break;
    }
}

void GerirCategorias(CategoriaService service)
{
    Console.WriteLine("\n--- CATEGORIAS ---");
    Console.WriteLine("1. Adicionar");
    Console.WriteLine("2. Listar");
    Console.WriteLine("3. Procurar");
    Console.WriteLine("4. Remover");
    Console.Write("Opção: ");

    switch (Console.ReadLine() ?? "")
    {
        case "1":
            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? "";
            try
            {
                categoriaService.AdicionarCategoria(new Categoria { Nome = nome });
                Console.WriteLine("Categoria adicionada!");
            }
            catch (Exception ex) { Console.WriteLine($"Erro: {ex.Message}"); }
            break;
        case "2":
            var cats = service.ListarCategorias();
            if (cats.Count == 0) Console.WriteLine("Nenhuma categoria.");
            else foreach (var c in cats)
                Console.WriteLine($"[{c.Id}] {c.Nome}");
            break;
        case "3":
            Console.Write("Nome: ");
            var cat = service.ProcurarPorCategoria(Console.ReadLine() ?? "");
            if (cat == null) Console.WriteLine("Não encontrada.");
            else Console.WriteLine($"[{cat.Id}] {cat.Nome}");
            break;
        case "4":
            Console.Write("ID: ");
            service.RemoverCategoria(int.Parse(Console.ReadLine() ?? "0"));
            Console.WriteLine("Removida!");
            break;
    }
}

void GerirRealizadores(RealizadorService service)
{
    Console.WriteLine("\n--- REALIZADORES ---");
    Console.WriteLine("1. Adicionar");
    Console.WriteLine("2. Listar");
    Console.WriteLine("3. Procurar");
    Console.WriteLine("4. Remover");
    Console.Write("Opção: ");

    switch (Console.ReadLine() ?? "")
    {
        case "1":
            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? "";
            Console.Write("País: ");
            string pais = Console.ReadLine() ?? "";
            try
            {
                realizadorService.AdicionarRealizador(new Realizador { Nome = nome, Pais = pais });
                Console.WriteLine("Realizador adicionado!");
            }
            catch (Exception ex) { Console.WriteLine($"Erro: {ex.Message}"); }
            break;
        case "2":
            var reals = service.ListarRealizadores();
            if (reals.Count == 0) Console.WriteLine("Nenhum realizador.");
            else foreach (var r in reals)
                Console.WriteLine($"[{r.Id}] {r.Nome} ({r.Pais})");
            break;
        case "3":
            Console.Write("Nome: ");
            var real = service.ProcurarPorRealizador(Console.ReadLine() ?? "");
            if (real == null) Console.WriteLine("Não encontrado.");
            else Console.WriteLine($"[{real.Id}] {real.Nome} ({real.Pais})");
            break;
        case "4":
            Console.Write("ID: ");
            service.RemoverRealizador(int.Parse(Console.ReadLine() ?? "0"));
            Console.WriteLine("Removido!");
            break;
    }
}