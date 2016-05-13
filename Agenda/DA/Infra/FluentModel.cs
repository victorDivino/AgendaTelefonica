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

        public FluentModel()
            : base("AgendaTelefonica", backend, metadataSource)
        { }

        public void ConsultarTodosContatos()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contatos = this.GetAll<Contato>().ToList();
            watch.Stop();
        }

        public void AdicionarNovoContato()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contato = new Contato()
            {
                Nome = "João",
                Email = "joao@email.com",
            };
            this.Add(contato);
            this.SaveChanges();
            watch.Stop();
        }

        public void AdicionarTelefone()
        {
            var watch = new Stopwatch();
            watch.Start();
            var contato = this.GetAll<Contato>().Last();
            contato.Telefones.Add(new Telefone()
            {
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
            var contato = this.GetAll<Contato>().Last();
            this.Delete(contato.Telefones);
            this.Delete(contato);
            this.SaveChanges();
            watch.Stop();
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

