using MovieManagement.Domain;

namespace MovieManagement.Business
{
    public class FilmeService
    {
        private readonly IFilmeRepository _repository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IRealizadorRepository _realizadorRepository;

        public FilmeService(IFilmeRepository repository, ICategoriaRepository categoriaRepository, IRealizadorRepository realizadorRepository)
        {
            _repository = repository;
            _categoriaRepository = categoriaRepository;
            _realizadorRepository = realizadorRepository;
        }

        public void AdicionarFilme(Filme filme)
        {
            if (string.IsNullOrEmpty(filme.Titulo))
                throw new Exception("O título é obrigatório.");

            if (_repository.ProcurarPorTitulo(filme.Titulo) != null)
                throw new Exception("Já existe um filme com esse título.");

            if (filme.Classificacao < 0 || filme.Classificacao > 5)
                throw new Exception("A classificação deve estar entre 0 e 5.");

            if (filme.CategoriaId <= 0)
                throw new Exception("A categoria não existe.");

            if (filme.RealizadorId <= 0)
                throw new Exception("O realizador não existe.");

            _repository.AdicionarFilme(filme);
        }

        public List<Filme> ListarFilmes()
        {
            return _repository.ListarFilmes();
        }

        public Filme? ProcurarPorTitulo(string titulo)
        {
            return _repository.ProcurarPorTitulo(titulo);
        }

        public void RemoverFilme(int id)
        {
            _repository.RemoverFilme(id);
        }
    }
}