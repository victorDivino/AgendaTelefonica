using System.Collections.Generic;

namespace NH
{
    public class Contato
    {
        public Contato()
        {
            this.Telefones = new List<Telefone>();
        }
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual IList<Telefone> Telefones { get; set; }
    }
}
