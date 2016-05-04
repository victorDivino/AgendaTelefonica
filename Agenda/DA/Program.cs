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
            using (var fluentModel = new FluentModel())
            {
                fluentModel.ConsultarTodosContatos();
                fluentModel.AdicionarNovoContato();
                fluentModel.AdicionarTelefone();
                fluentModel.DeletarContato();
            }
        }
    }
}
