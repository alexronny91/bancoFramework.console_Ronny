using Domain.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var pessoa = Identificacao();
    }

    static Pessoa Identificacao()
    {
        var pessoa = new Pessoa();

        Console.WriteLine("Seu número de identificação:");
        pessoa.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Seu nome:");
        pessoa.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        pessoa.Cpf = Console.ReadLine();
        Console.Clear();

        string opcao;
        do
        {
            Console.WriteLine($"Como posso ajudar {pessoa.Nome}?");
            Console.WriteLine("1 - Depósito");
            Console.WriteLine("2 - Saque");
            Console.WriteLine("3 - Sair");
            Console.WriteLine("----------");
            Console.WriteLine("Selecione uma opção:");
            opcao = Console.ReadLine();

            if (opcao == "1")
            {
                Console.WriteLine("Depósito");
                return pessoa;
            }
            else if (opcao == "2")
            {
                Console.WriteLine("Saque");
                return pessoa;
            }
            else if (opcao == "3")
            {
                break;
            }
            else
            {
                Console.Clear();
            }

        } while (opcao != "3");

        return pessoa;
    }
}