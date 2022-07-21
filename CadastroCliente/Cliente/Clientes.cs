using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cliente
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Tel { get; set; }
        public string Sexo { get; set; }

        
        /// <summary>
        ///     Contrutor dos Clientes
        /// </summary>
        /// <param name="_nome"></param>
        /// <param name="_cpf"></param>
        /// <param name="_telefone"></param>
        /// <param name="_sexo"></param>
        public Clientes(string _nome, string _cpf, string _telefone, string _sexo)
        { 
            this.Nome = _nome;
            this.Cpf = _cpf;
            this.Tel = _telefone;
            this.Sexo = _sexo;
        }



        public Clientes() 
        {
        
        }

        /*
            1 - usuario do app vai digitar o nome da pasta.
            2 - usuario vai digitar o nome do arquivo com os dados.
            3 - usuario irá ter que ter na máquina por padrão uma pasta chamada db.
            4 - todos os arquivos terão que ser .txt
            5 - PADRÃO de criação dos nomes dos arquivos tem que está em letra de forma.

            Get - Para metodos de leitura.
            Set - Para metodos que vai mudar o valor.

            Metodo de intacia serve para "UM" 
            Metodo estatico serva para "MUITOS"
         */

        private static string GetLerArquivos()
        {
            string caminho = $@"C:\db\CLIENTE\CLIENTES_LOJA.txt";

            return caminho;
        }

        public void SetGravar()
        {
            var clientes = Clientes.LerCliente();
            clientes.Add(this);

            if (File.Exists(GetLerArquivos()))
            {
                StreamWriter Writer = new StreamWriter(GetLerArquivos());
                Writer.WriteLine("Nome;Cpf;Tel;Sexo;");
                foreach(Clientes c in clientes)
                {
                    var linha = c.Nome + ";" + c.Cpf + ";" + c.Tel + ";" + c.Sexo;
                    Writer.WriteLine(linha);
                }

                Writer.Close();
            }
        }

        public static List<Clientes> LerCliente()
        {
            var clientes = new List<Clientes>();

            if (File.Exists(GetLerArquivos()))
            {
                using (StreamReader arquivo = File.OpenText(GetLerArquivos()))
                {
                    string linha;
                    int i = 0;
                    while ((linha = arquivo.ReadLine()) != null)
                    {
                        i++;
                        if (i == 1) continue;
                        var clienteArquivo = linha.Split(";");

                        var cliente = new Clientes(
                           clienteArquivo[0],
                           clienteArquivo[1],
                           clienteArquivo[2],
                           clienteArquivo[3]
                        );

                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }
    }
}
