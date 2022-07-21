using System;
using Cliente;

namespace CadastroCliente
{
    public class Program
    {
        private static void Cadastro()
        {
            var p1 = new Clientes();

            Console.Write("Escreva nome: ");
            p1.Nome = Console.ReadLine();
            Console.Write("\nEscreva Cpf: ");
            p1.Cpf = Console.ReadLine();
            Console.Write("\nEscreva Tel: ");
            p1.Tel = Console.ReadLine();
            Console.Write("\nEscreva Sexo: ");
            p1.Sexo = Console.ReadLine();
            Console.Clear();
            p1.SetGravar();
        }

        private static void LerCadastrado()
        {
            var cliente = Clientes.LerCliente();

            foreach (Clientes c in cliente)
            {
                Console.WriteLine($"{c.Nome};{c.Cpf};{c.Tel};{c.Sexo};");
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            string respota2 = Console.ReadLine().ToUpper();
            if (respota2 == "SIM") Cadastro();

            Console.Clear();

            Console.WriteLine("Escreva 1 se quer continuar");
            char resposta = char.Parse(Console.ReadLine());
            if (resposta == '1') Cadastro();
            else if (resposta == '2')
            {
                LerCadastrado();
            }
        }
    }
}
