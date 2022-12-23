using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O Que Você Deseja fazer?");
            Console.WriteLine("1 - Abrir Aquivo");
            Console.WriteLine("2 - Criar novo Arquivo");
            Console.WriteLine("0 - Sair ");

            short opcao = short.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    Abrir();
                    break;
                case 2:
                    Editar();
                    break;
                default: Menu(); break;

            }


        }


        static void Abrir()
        {
            Console.WriteLine("Qual caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string texto = file.ReadToEnd();
                Console.WriteLine(texto);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu Texto Abaixo");
            string texto = "";

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(texto);

        }

        static void Salvar(string texto)
        {
            Console.WriteLine("Qual Caminho pra salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(texto);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso");
            Console.ReadLine();
            Menu();

        }
    }


}