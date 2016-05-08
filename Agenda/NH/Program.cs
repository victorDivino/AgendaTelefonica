using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NH
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sessionFactory = new SessionFactory())
            {
                sessionFactory.ConsultarTodosContatos();
                sessionFactory.CadastrarNovoContato();
                sessionFactory.AdicionarTelefone();
                sessionFactory.DeletarContato();
            }
        }
    }
}
