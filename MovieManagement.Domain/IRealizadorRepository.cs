using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Domain
{
    public interface IRealizadorRepository
    {
            void AdicionarRealizador(Realizador realizador);
            List<Realizador> ListarRealizadores();
            Realizador? ProcurarRealizador(string nome);
            void RemoverRealizador(int id);

    }

}