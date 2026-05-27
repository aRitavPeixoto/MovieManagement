using System;
using System.Collections.Generic;
using System.Text;
using MovieManagement.Domain;

namespace MovieManagement.Data
{
    public class FilmeRepositoryMemoria : IFilmeRepository
    {
        private List<Filme> _filmes = new List<Filme>();

        public void AdicionarFilme(Filme filme)
        {
            _filmes.Add(filme);
        }

        public List<Filme> ListarFilmes()
        {
            return _filmes;
        }

        public Filme? ProcurarPorTitulo(string titulo)
        {
            return _filmes.FirstOrDefault(f => f.Titulo == titulo);
        }

        public void RemoverFilme(int id)
        {
            var filme = _filmes.FirstOrDefault(f => f.Id == id);
            if (filme != null)
                _filmes.Remove(filme);
        }
    }
}

