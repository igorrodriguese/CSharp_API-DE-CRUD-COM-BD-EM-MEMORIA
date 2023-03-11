using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeiraApi.BancoEmMemoria
{
    public interface ITarefaRepository
    {
        void Create(Tarefa tarefa);

        Task<IEnumerable<Tarefa>> Get();

        Task Update(Tarefa tarefa);

        Task Delete(int id);
    }
}