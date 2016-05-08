
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;


namespace EF
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("AgendaTelefonica")
        { }

        public DbSet<Contato> Contato { get; set; }
        public DbSet<Telefone> Telefone { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContatoMap());
            modelBuilder.Configurations.Add(new TelefoneMap());
            base.OnModelCreating(modelBuilder);
        }

        public void ConsultarTodosContatos()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contatos = this.Contato.ToList();
            watch.Stop();
        }

        public void CadastrarNovoContato()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contato = new Contato()
            {
                Nome = "João",
                Email = "joao@email.com",
            };
            this.Contato.Add(contato);
            this.SaveChanges();
            watch.Stop();
        }

        public void AdicionarTelefone()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contato = this.Contato.First();
            contato.Telefones.Add(new Telefone()
            {
                IdContato = contato.Id,
                DDD = "85",
                Numero = "999999999"
            });
            this.SaveChanges();
            watch.Stop();
        }

        public void DeletarContato()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contato = this.Contato.First();
            this.Contato.Remove(contato);
            this.SaveChanges();
            watch.Stop();
        }
    }
}
