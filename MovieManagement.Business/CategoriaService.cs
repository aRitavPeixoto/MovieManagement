using MovieManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

namespace MovieManagement.Business
{
    // Regras Negócio

    public class CategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public void AdicionarCategoria(Categoria categoria)
        {
            if (string.IsNullOrEmpty(categoria.Nome))
                throw new Exception("O nome é obrigatório.");

            if (_repository.ProcurarPorCategoria(categoria.Nome) != null)
                throw new Exception("Já existe uma categoria com esse nome.");

             _repository.AdicionarCategoria(categoria);
        }
        public List<Categoria> ListarCategorias()
        {
            return _repository.ListarCategorias();
        }

        public Categoria? ProcurarPorCategoria(string nome)
        {
            return _repository.ProcurarPorCategoria(nome);
        }

        public void RemoverCategoria(int id)
        {
            _repository.RemoverCategoria(id);
        }
    }
}
