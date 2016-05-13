using FluentNHibernate.Mapping;

namespace NH
{
    public class TelefoneMap : ClassMap<Telefone>
    {
        public TelefoneMap()
        {
            Id(m => m.Id).GeneratedBy.Identity();
            Map(m => m.DDD);
            Map(m => m.Numero);
            Map(m => m.IdContato);
            References(m => m.Contato, "IdContato").ReadOnly();
        }
    }
}
