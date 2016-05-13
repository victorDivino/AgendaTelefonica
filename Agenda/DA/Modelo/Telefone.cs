using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class Telefone
    {
        public virtual int Id { get; set; }
        public virtual int IdContato { get; set; }
        public virtual string DDD { get; set; }
        public virtual string Numero { get; set; }
        public virtual Contato Contato { get; set; }
    }
}
