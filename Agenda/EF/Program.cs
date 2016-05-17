using System;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            long consultarTodosContatos = 0;
            long adicionarNovoContato = 0;
            long adicionarTelefone = 0;
            long deletarContato = 0;

            for (int i = 0; i < 3; i++)
            {
                using (var sessionFactory = new Contexto())
                {
                    consultarTodosContatos += sessionFactory.ConsultarTodosContatos();
                    adicionarNovoContato += sessionFactory.AdicionarNovoContato();
                    adicionarTelefone += sessionFactory.AdicionarTelefone();
                    deletarContato += sessionFactory.DeletarContato();
                }
            }

            var mediaConsultarTodosContatos = consultarTodosContatos / 3;
            var mediaAdicionarNovoContato = adicionarNovoContato / 3;
            var mediaAdicionarTelefone = adicionarTelefone / 3;
            var mediaDeletarContato = deletarContato / 3;
            var mediaTotal = mediaConsultarTodosContatos + mediaAdicionarNovoContato + mediaAdicionarTelefone + mediaDeletarContato;

            Console.WriteLine($"mediaConsultarTodosContatos = { mediaConsultarTodosContatos } ");
            Console.WriteLine($"mediaAdicionarNovoContato = { mediaAdicionarNovoContato } ");
            Console.WriteLine($"mediaAdicionarTelefone = { mediaAdicionarTelefone } ");
            Console.WriteLine($"mediaDeletarContato = { mediaDeletarContato } ");
            Console.WriteLine($"mediaTotal = { mediaTotal } ");
        }
    }
}
