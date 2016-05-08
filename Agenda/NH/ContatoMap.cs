using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NH
{
    public class ContatoMap : ClassMap<Contato>
    {
        public ContatoMap()
        {
            Id(m => m.Id).GeneratedBy.Identity();
            Map(m => m.Nome);
            Map(m => m.Email);
            HasMany(x => x.Telefones).Cascade.AllDeleteOrphan().Inverse();
        }
    }
}
