using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Domain
{
    public interface IFilmeRepository
    {
        void AdicionarFilme(Filme filme);
        List<Filme> ListarFilmes();
        Filme ProcurarPorTitulo(string titulo);
        void RemoverFilme(int id);
    }
}
