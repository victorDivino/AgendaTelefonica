using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class ContatoMap : EntityTypeConfiguration<Contato>
    {
        public ContatoMap()
        {
            ToTable("Contato");
            HasKey(m => m.Id);

            Property(m => m.Id).HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Nome).HasColumnName("Nome");
            Property(m => m.Email).HasColumnName("Email");

            HasMany(m => m.Telefones)
                .WithOptional()
                .HasForeignKey(m => m.IdContato)
                .WillCascadeOnDelete();
                
        }
    }
}
