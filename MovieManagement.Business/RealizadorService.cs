using MovieManagement.Domain;

namespace MovieManagement.Business
{
    public class RealizadorService
    {
        private readonly IRealizadorRepository _repository;

        public RealizadorService(IRealizadorRepository repository)
        {
            _repository = repository;
        }

        public void AdicionarRealizador(Realizador realizador)
        {
            if (string.IsNullOrEmpty(realizador.Nome))
                throw new Exception("O nome é obrigatório.");

            if (string.IsNullOrEmpty(realizador.Pais))
                throw new Exception("O país é obrigatório.");

            _repository.AdicionarRealizador(realizador);
        }

        public List<Realizador> ListarRealizadores()
        {
            return _repository.ListarRealizadores();
        }

        public Realizador? ProcurarRealizador(string nome)
        {
            return _repository.ProcurarRealizador(nome);
        }

        public void RemoverRealizador(int id)
        {
            _repository.RemoverRealizador(id);
        }
    }
}