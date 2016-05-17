using System;
using System.Diagnostics;
using System.Linq;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;

namespace DA
{
    class FluentModel : OpenAccessContext
    {
        private static BackendConfiguration backend = GetBackendConfiguration();
        private static MetadataSource metadataSource = new FluentModelMetadataSource();
        private int idContato;

        public FluentModel()
            : base("AgendaTelefonica", backend, metadataSource)
        { }

        public long ConsultarTodosContatos()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contatos = this.GetAll<Contato>().ToList();
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
            this.Add(contato);
            this.SaveChanges();
            watch.Stop();
            idContato = contato.Id;
            return watch.ElapsedMilliseconds;
        }

        public long AdicionarTelefone()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contato = this.GetAll<Contato>().First(c => c.Id == idContato);
            contato.Telefones.Add(new Telefone()
            {
                IdContato = idContato,
                DDD = "99",
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
            var contato = this.GetAll<Contato>().First(c => c.Id == idContato);
            this.Delete(contato.Telefones);
            this.Delete(contato);
            this.SaveChanges();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public static BackendConfiguration GetBackendConfiguration()
        {
            BackendConfiguration backend = new BackendConfiguration();
            backend.Backend = "MsSql";
            backend.ProviderName = "System.Data.SqlClient";
            return backend;
        }
    }
}

