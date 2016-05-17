using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Diagnostics;
using System.Linq;

namespace NH
{
    public class SessionFactory : IDisposable
    {
        private ISessionFactory _sessionFactory;
        private ISession _session;
        private int idContato;

        public SessionFactory()
        {
            _sessionFactory = Fluently.Configure()
               .Database(MsSqlConfiguration
                   .MsSql2012
                   .ConnectionString(c => c.FromConnectionStringWithKey("AgendaTelefonica")))
               .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Program>())
               .BuildSessionFactory();
            _session = _sessionFactory.OpenSession();
        }

        public long ConsultarTodosContatos()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contatos = _session.Query<Contato>().ToList();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public long AdicionarNovoContato()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contato = new Contato()
            {
                Nome = "fulano",
                Email = "fulano@email.com",
            };
            _session.Save(contato);
            _session.Flush();
            idContato = contato.Id;
            return watch.ElapsedMilliseconds;
        }

        public long AdicionarTelefone()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contato = _session.Query<Contato>().First(c => c.Id == idContato);
            contato.Telefones.Add(new Telefone()
            {
                IdContato = idContato,
                DDD = "99",
                Numero = "999999999"
            });
            _session.SaveOrUpdate(contato);
            _session.Flush();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public long DeletarContato()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contato = _session.Query<Contato>().First(c => c.Id == idContato);
            _session.Delete(contato);
            _session.Flush();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        public void Dispose()
        {
            _sessionFactory.Dispose();
        }
    }
}
