using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    class Program
    {
        static void Main(string[] args)
        {
            var fluentModel = new FluentModel();
            var contatos = fluentModel.Contatos.ToList();
            //fluentModel.Adicionar();
            //var telefones = fluentModel.Telefones.ToList();
        }
    }
}
