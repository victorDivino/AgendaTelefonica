using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;

namespace DA
{
    public class FluentModelMetadataSource : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            List<MappingConfiguration> configurations = new List<MappingConfiguration>();

            var contatoMap = new MappingConfiguration<Contato>();
            contatoMap.MapType(contato => new
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Email = contato.Email
            }).ToTable("Contato");
            contatoMap.HasProperty(c => c.Id).IsIdentity(KeyGenerator.Autoinc);
            contatoMap.HasAssociation(c => c.Telefones)
                .HasConstraint((c, t) => t.IdContato == c.Id)
                .IsManaged()
                .WithDataAccessKind(DataAccessKind.ReadWrite);

            var telefoneMap = new MappingConfiguration<Telefone>();
            telefoneMap.MapType(telefone => new
            {
                Id = telefone.Id,
                IdContato = telefone.IdContato,
                DDD = telefone.DDD,
                Numero = telefone.Numero
            }).ToTable("Telefone");
            telefoneMap.HasProperty(c => c.Id).IsIdentity(KeyGenerator.Autoinc);
            telefoneMap.HasAssociation(t => t.Contato)
                .WithOpposite(c => c.Telefones)
                .HasConstraint((t, c) => t.IdContato == c.Id)
                .IsManaged()
                .WithDataAccessKind(DataAccessKind.ReadWrite);

            configurations.Add(contatoMap);
            configurations.Add(telefoneMap);
            return configurations;
        }
    }
}
