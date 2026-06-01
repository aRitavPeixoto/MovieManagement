using System;
using System.Collections.Generic;
using System.Text;
using MovieManagement.Domain;

namespace MovieManagement.Business
{
    public class FilmeService
    {
        private readonly IFilmeRepository _repository;

        public FilmeService(IFilmeRepository repository)
        {
            _repository = repository;
        }


        public void AdicionarFilme(Filme filme)
        {
            if (string.IsNullOrEmpty(filme.Titulo))
                throw new Exception("O título é obrigatório.");

            if (_repository.ProcurarPorTitulo(filme.Titulo) != null)
                throw new Exception("Já existe um filme com esse título.");

            if (filme.Classificacao < 0 || filme.Classificacao > 5)
                throw new Exception("A classificação deve estar entre 0 e 5.");

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