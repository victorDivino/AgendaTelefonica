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

        public SessionFactory()
        {
            _sessionFactory = Fluently.Configure()
               .Database(MsSqlConfiguration
                   .MsSql2012
                   .ConnectionString(c => c.FromConnectionStringWithKey("AgendaTelefonica"))
                   .ShowSql())
               .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Program>())
               .BuildSessionFactory();

            _session = _sessionFactory.OpenSession();
        }

        public void ConsultarTodosContatos()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contatos = _session.Query<Contato>().ToList();
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
            _session.Save(contato);
            _session.Flush();
            watch.Stop();
        }

        public void AdicionarTelefone()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contato = _session.Query<Contato>().First();
            contato.Telefones.Add(new Telefone()
            {
                IdContato = contato.Id,
                DDD = "85",
                Numero = "999999999"
            });
            _session.SaveOrUpdate(contato);
            _session.Flush();
            watch.Stop();
        }

        public void DeletarContato()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contato = _session.Query<Contato>().First();
            _session.Delete(contato);
            _session.Flush();
            watch.Stop();
        }
        public void Dispose()
        {
            _sessionFactory.Dispose();
        }
    }
}
