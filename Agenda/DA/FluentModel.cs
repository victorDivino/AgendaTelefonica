using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;

namespace DA
{
    class FluentModel : OpenAccessContext
    {
        private static string connectionStringName = @"AgendaTelefonica";

        private static BackendConfiguration backend =
            GetBackendConfiguration();

        private static MetadataSource metadataSource =
            new FluentModelMetadataSource();

        public FluentModel()
            : base(connectionStringName, backend, metadataSource)
        { }

        public IQueryable<Contato> Contatos
        {
            get
            {
                return this.GetAll<Contato>();
            }
        }

        public IQueryable<Telefone> Telefones
        {
            get
            {
                return this.GetAll<Telefone>();
            }
        }


        public void Adicionar()
        {
            this.Add(new Contato() {
                Nome = "João",
                Email = "joao@email.com"
            });
            this.SaveChanges();
            this.Dispose();
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
 
