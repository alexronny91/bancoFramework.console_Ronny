using Domain.Model;
using Application;
using CpfCnpjLibrary;
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
        List<string> erros = new List<string>();
        string opcao;
        float deposito;
        float saque;
        Boolean cpfValido;

        do
        {
            erros.Clear();

            Console.WriteLine("Seu número de identificação:");
            string inputId = Console.ReadLine();

            if (int.TryParse(inputId, out int id) && id > 0)
            {
                cliente.Id = id;
            }
            else
            {
                erros.Add("Identificador não é válido");
            }

            Console.WriteLine("Seu nome:");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Seu CPF:");
            cliente.Cpf = Console.ReadLine();
            cpfValido = Cpf.Validar(cliente.Cpf);

            if (!cpfValido)
            {
                erros.Add("CPF digitado não é válido");
            }        

            Console.WriteLine("Seu saldo:");
            string inputSaldo = Console.ReadLine();

            if (float.TryParse(inputSaldo, out float saldo) && saldo >= 0)
            {
                cliente.Saldo = saldo;
            }
            else
            {
                erros.Add("Saldo não é válido");
            }

            if (erros.Count == 0)
            {
                break;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Ocorreram os seguintes erros:");
                foreach (var erro in erros)
                {
                    Console.WriteLine($"- {erro}");
                }
                Console.ReadKey();
                Console.Clear();
            }

        }
        while (true);

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
