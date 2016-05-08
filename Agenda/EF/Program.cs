namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new Contexto())
            {
                contexto.ConsultarTodosContatos();
                contexto.CadastrarNovoContato();
                contexto.AdicionarTelefone();
                contexto.DeletarContato();
            }
        }
    }
}
