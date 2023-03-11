using Microsoft.EntityFrameworkCore;

namespace PrimeiraApi.BancoEmMemoria
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "MemoryDb");
        }

        public DbSet<Tarefa> Tarefas { get; set; }    
    }
}