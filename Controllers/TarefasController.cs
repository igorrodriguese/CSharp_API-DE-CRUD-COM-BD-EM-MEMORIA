using System.Collections.Generic;
using System.Threading.Tasks;
using PrimeiraApi.BancoEmMemoria;
using Microsoft.AspNetCore.Mvc;

namespace PrimeiraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepository _tarefas;

        public TarefasController(ITarefaRepository tarefas)
        {
            _tarefas = tarefas;
        }

        [HttpPost]
        public void Create([FromBody] Tarefa tarefa)
        {
            _tarefas.Create(tarefa);
        }

        [HttpGet]
        public async Task<IEnumerable<Tarefa>> Get()
        {
            return await _tarefas.Get();
        }

        [HttpPut]
        public void Update([FromBody] Tarefa tarefaAtualizada)
        {
            _tarefas.Update(tarefaAtualizada);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            _tarefas.Delete(id);
        }
    }
}