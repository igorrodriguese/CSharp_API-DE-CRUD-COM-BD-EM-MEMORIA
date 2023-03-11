using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PrimeiraApi.BancoEmMemoria
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly Context _context;
        private readonly DbSet<Tarefa> _db;

        public TarefaRepository(Context context)
        {
            _context = context;
            _db = context.Set<Tarefa>();
        }

        public void Create(Tarefa tarefa)
        {
            _db.Add(tarefa);

            _context.SaveChanges();
        }

        public async Task<IEnumerable<Tarefa>> Get()
        {
            return await _db.ToListAsync();
        }

        public async Task Update(Tarefa tarefaAtualizada)
        {
            var tarefaExistente = await _db.FirstOrDefaultAsync(tarefa => tarefa.Id == tarefaAtualizada.Id);

            tarefaExistente.Titulo = tarefaAtualizada.Titulo;

            _db.Update(tarefaExistente);

            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var tarefa = await _db.FirstOrDefaultAsync(tarefa => tarefa.Id == id);
            _db.Remove(tarefa);

            _context.SaveChanges();
        }
    }
}