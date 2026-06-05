using MovieManagement.Domain;

namespace MovieManagement.Data
{
    public class CategoriaRepositoryMemoria : ICategoriaRepository
    {
        private List<Categoria> _categorias = new List<Categoria>();

        public void AdicionarCategoria(Categoria categoria)
        {
            categoria.Id = _categorias.Count + 1;
            _categorias.Add(categoria);
        }

        public List<Categoria> ListarCategorias()
        {
            return _categorias;
        }

        public Categoria? ProcurarPorCategoria(string nome)
        {
            return _categorias.FirstOrDefault(c => c.Nome == nome);
        }

        public void RemoverCategoria(int id)
        {
            var categoria = _categorias.FirstOrDefault(c => c.Id == id);
            if (categoria != null)
                _categorias.Remove(categoria);
        }
    }
}