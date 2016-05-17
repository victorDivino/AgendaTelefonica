
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;


namespace EF
{
    public class Contexto : DbContext
    {
        private int idContato;

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

        public long ConsultarTodosContatos()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contatos = this.Contato.ToList();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public long AdicionarNovoContato()
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
            idContato = contato.Id;
            return watch.ElapsedMilliseconds;
        }

        public long AdicionarTelefone()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contato = this.Contato.First(c => c.Id == idContato);
            contato.Telefones.Add(new Telefone()
            {
                IdContato = idContato,
                DDD = "85",
                Numero = "999999999"
            });
            this.SaveChanges();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public long DeletarContato()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contato = this.Contato.First(c => c.Id == idContato);
            this.Contato.Remove(contato);
            this.SaveChanges();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}
