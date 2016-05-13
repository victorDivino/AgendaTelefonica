using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;

namespace DA.Infra
{
    public class TelefoneMap : MappingConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            this.MapType(telefone => new
            {
                Id = telefone.Id,
                IdContato = telefone.IdContato,
                DDD = telefone.DDD,
                Numero = telefone.Numero
            }).ToTable("Telefone");
            this.HasProperty(c => c.Id).IsIdentity(KeyGenerator.Autoinc);
            this.HasAssociation(t => t.Contato)
                .WithOpposite(c => c.Telefones)
                .HasConstraint((t, c) => t.IdContato == c.Id)
                .IsManaged()
                .WithDataAccessKind(DataAccessKind.ReadWrite);
        }
    }
}
