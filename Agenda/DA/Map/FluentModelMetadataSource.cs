using System.Collections.Generic;
using DA.Infra;
using Telerik.OpenAccess.Metadata.Fluent;

namespace DA
{
    public class FluentModelMetadataSource : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
            => new List<MappingConfiguration>
            {
                new ContatoMap(),
                new TelefoneMap()
            };
    }
}
