using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class TelefoneMap : EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            ToTable("Telefone");

            HasKey(m => m.Id);

            Property(m => m.Id).HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(m => m.DDD).HasColumnName("DDD");
            Property(m => m.Numero).HasColumnName("Numero");
            Property(m => m.IdContato).HasColumnName("IdContato");

            HasRequired(m => m.Contato)
                .WithMany()
                .HasForeignKey(m => m.IdContato);

        }
    }
}
