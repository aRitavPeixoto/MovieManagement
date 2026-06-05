using MovieManagement.Domain;

namespace MovieManagement.Data
{
    public class RealizadorRepositoryMemoria : IRealizadorRepository
    {
        private List<Realizador> _realizadores = new List<Realizador>();

        public void AdicionarRealizador(Realizador realizador)
        {
            realizador.Id = _realizadores.Count + 1;
            _realizadores.Add(realizador);
        }

        public List<Realizador> ListarRealizadores()
        {
            return _realizadores;
        }

        public Realizador? ProcurarRealizador(string nome)
        {
            return _realizadores.FirstOrDefault(r => r.Nome == nome);
        }

        public void RemoverRealizador(int id)
        {
            var realizador = _realizadores.FirstOrDefault(r => r.Id == id);
            if (realizador != null)
                _realizadores.Remove(realizador);
        }
    }
}