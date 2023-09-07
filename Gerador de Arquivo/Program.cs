using System;
using System.IO;

namespace GeradordeArquivo;

public class Program
{
    const string ext = ".txt";

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(@"
Selecione uma opção:

1. Criar nota;
2. Ler nota;
3. Editar arquivo no Bloco de Notas;
4. Deletar nota;
5. Sair.");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    CreateFile();
                    break;

                case "2":
                    Console.Clear();
                    ReadFile();
                    break;

                case "3":
                    Console.Clear();
                    OpenNote();
                    break;

                case "4":
                    Console.Clear();
                    DeleteNote();
                    break;

                case "5":
                    return;

                case "":
                    return;

                default:
                    Console.Clear();
                    Console.WriteLine("Erro, opção inválida");
                    Console.ReadKey();
                    break;
            }
        }
        
    }

    static void CreateFile()
    {
        Console.Write("Crie um título para a nota: ");
        string name = Console.ReadLine();

        string _file = name + ext;
        EditText(_file);
    }

    static void ReadFile()
    {
        Console.WriteLine("Digite o título da nota que você quer ler: ");
        string name = Console.ReadLine();
        string pathing = file_path + name + ext;


        if (File.Exists(pathing))
        {
            var file = File.ReadAllText(pathing);
            
            Console.Clear();
            Console.WriteLine(@$"
{name}

{file}");
        }
        else
        {
            Console.WriteLine($"O arquivo {name} não existe.");
        }

        Console.ReadKey();
    }

    static void EditText(string _name)
    {
        StreamWriter stream_writer;

        if (File.Exists(file_path + _name))
        {
            Console.WriteLine($"O arquivo {_name} já existe.");
        }
        else
        {
            stream_writer = File.CreateText(file_path + _name);

            Console.Clear();
            Console.WriteLine("Nota criada com sucesso! Escreva o conteúdo da nota: ");

            string content = Console.ReadLine();
            stream_writer.Write(content);
            stream_writer.Close();
        }
    }

    static void OpenNote()
    {
        {
            Console.Clear();
            Console.WriteLine("Qual o título da nota que deseja abrir?");

            string name = Console.ReadLine();
            string pathing = file_path + name + ext;

            if (File.Exists(pathing))
            {
                System.Diagnostics.Process.Start("notepad", pathing);
            }
            else
            {
                Console.WriteLine($"O arquivo {name} não existe.");
                Console.ReadKey();
            }

        }
    }

    static void DeleteNote()
    {
        Console.Write("Digite o título da nota que deseja excluir: ");
        string name = Console.ReadLine();

        string path = file_path + name + ext;
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Console.WriteLine($"O arquivo {name + ext} não existe e não pode ser deletado.");
            Console.ReadKey();
        }
    }
}