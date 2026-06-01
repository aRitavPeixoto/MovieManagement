using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Domain
{
    public interface ICategoriaRepository
    {
        void AdicionarCategoria(Categoria categoria);
        List<Categoria> ListarCategorias();
        Categoria? ProcurarPorCategoria(string nome);
        void RemoverCategoria(int id);
    }
}
