using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;

namespace DA
{
    public class ContatoMap : MappingConfiguration<Contato>
    {
        public ContatoMap()
        {
            this.MapType(contato => new
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Email = contato.Email
            }).ToTable("Contato");
            this.HasProperty(c => c.Id).IsIdentity(KeyGenerator.Autoinc);
            this.HasAssociation(c => c.Telefones)
                .HasConstraint((c, t) => t.IdContato == c.Id)
                .IsManaged()
                .WithDataAccessKind(DataAccessKind.ReadWrite);
        }
    }
}
