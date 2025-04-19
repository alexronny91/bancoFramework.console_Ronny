using Domain.Model;
using Application;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao banco Framework");
        Console.WriteLine("Por favor, identifique-se");
        Console.WriteLine("");
        var cliente = Identificacao();
    }

    static Cliente Identificacao()
    {
        var cliente = new Cliente();
        var calculo = new Calculo();

        Console.WriteLine("Seu número de identificação:");
        cliente.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Seu nome:");
        cliente.Nome = Console.ReadLine();

        Console.WriteLine("Seu CPF:");
        cliente.Cpf = Console.ReadLine();

        Console.WriteLine("Seu saldo:");
        cliente.Saldo = float.Parse(Console.ReadLine());

        string opcao;
        float deposito;
        float saque;
        do
        {
            Console.Clear();
            Console.WriteLine($"Como posso ajudar {cliente.Nome}?");
            Console.WriteLine("1 - Depósito");
            Console.WriteLine("2 - Saque");
            Console.WriteLine("3 - Sair");
            Console.WriteLine("----------");
            Console.WriteLine("Selecione uma opção:");
            opcao = Console.ReadLine();

            if (opcao == "1")
            {
                Console.Clear();
                Console.WriteLine("Digite o valor:");
                deposito = float.Parse(Console.ReadLine());
                cliente.Saldo = calculo.Soma(cliente.Saldo, deposito);
                Console.WriteLine($"Saldo atual é: {cliente.Saldo}");
                Console.ReadKey();
            }
            else if (opcao == "2")
            {
                Console.Clear();
                Console.WriteLine("Digite o valor:");
                saque = float.Parse(Console.ReadLine());
                cliente.Saldo = calculo.Subtracao(cliente.Saldo, saque);
                Console.WriteLine($"Saldo atual é: {cliente.Saldo}");
                Console.ReadKey();
            }
            else if (opcao == "3")
            {
                break;
            }

        } while (opcao != "3");

        return cliente;
    }
}