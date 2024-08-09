using System;

namespace Nomes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] listanomes = new string[10];
            bool controle = true;
            while (controle)
            {
                Console.WriteLine("Digite o índice da operação a ser realizada: \n 1 - Adicionar nomes; \n 2 - Adicionar nomes em índices específicos; \n 3 - Mostrar todos os nomes; \n 4 - Remover um nome; \n 5 - Sair.");
                string inputinicio = Console.ReadLine();
                int digitoinicio = int.Parse(inputinicio);
                switch (digitoinicio)
                {
                    case 1:
                        if (ListaCheia(listanomes))
                        {
                            Console.WriteLine("A lista de nomes está cheia.");
                            break;
                        }
                        bool loop = true;
                        while (loop)
                        {
                            Console.WriteLine("Digite o nome a ser adicionado ou pressione 'e' para retornar ao menu inicial:");
                            string input = Console.ReadLine();
                            if (input.ToLower() == "e")
                            {
                                loop = false;
                            }
                            else
                            {
                                AddNomes(listanomes, input);
                            }
                        }
                        break;
                    case 2:
                        if (ListaCheia(listanomes))
                        {
                            Console.WriteLine("A lista está cheia.");
                            break;
                        }
                        bool loop2 = true;
                        while (loop2)
                        {
                            Console.WriteLine("Digite o nome a ser adicionado na posição específica ou pressione 'e' para retornar ao menu inicial:");
                            string input2 = Console.ReadLine();
                            if (input2.ToLower() == "e")
                            {
                                loop2 = false;
                            }
                            else
                            {
                                Console.WriteLine("Digite o índice do nome a ser adicionado (1-10):");
                                string inputdigito = Console.ReadLine();
                                int digito = int.Parse(inputdigito) - 1;
                                AddEsp(listanomes, input2, digito);
                            }
                        }
                        break;
                    case 3:
                        if (ListaVazia(listanomes))
                        {
                            Console.WriteLine("A lista está vazia.");
                            break;
                        }
                        else
                        {
                            Show(listanomes);
                        }
                        break;
                    case 4:
                        if (ListaVazia(listanomes))
                        {
                            Console.WriteLine("A lista está vazia.");
                            break;
                        }
                        bool loop3 = true;
                        while (loop3)
                        {
                            Console.WriteLine("Digite o índice do nome a ser removido (1-10) ou pressione 'e' para sair ou pressione 'x' para limpar a lista:");
                            string inputdelete = Console.ReadLine();
                            if(inputdelete.ToLower() == "e")
                            {
                                loop3 = false;
                            }
                            int digitodelete = int.Parse(inputdelete) - 1;
                            Console.WriteLine("Deseja reagrupar os nomes ('s'/'n')?");
                            string inputregroup = Console.ReadLine();
                            Delete(listanomes, digitodelete, inputregroup);
                        }
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Dígito inválido.");
                        break;
                }
            }
        }
        static void AddNomes(string[] listanomes, string input)
        {
            for (int i = 0; i < listanomes.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(listanomes[i]))
                {
                    listanomes[i] = input;
                    break;
                }
            }
        }

        public static bool ListaCheia(string[] listanomes)
        {
            for (int i = 0; i < listanomes.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(listanomes[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ListaVazia(string[] listanomes)
        {
            for (int i = 0; i < listanomes.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(listanomes[i]))
                {
                    return false;
                }
            }
            return true;
        }

        static void AddEsp(string[] listanomes, string input2, int digito)
        {
            if (string.IsNullOrWhiteSpace(listanomes[digito]))
            {
                listanomes[digito] = input2;
            }
            else
            {
                bool shiftr = false;
                for (int i = digito; i < listanomes.Length - 1; i++)
                {
                    if (string.IsNullOrWhiteSpace(listanomes[i]))
                    {
                        int digitolivrer = i;
                        for (int i2 = digitolivrer; i2 > digito; i2--)
                        {
                            listanomes[i2] = listanomes[i2 - 1];
                        }
                        listanomes[digito] = input2;
                        shiftr = true;
                        break;
                    }
                }
                if (!shiftr)
                {
                    for (int i3 = digito; i3 < listanomes.Length - 1 && i3 > 0; i3--)
                    {
                        if (string.IsNullOrWhiteSpace(listanomes[i3]))
                        {
                            int digitolivrel = i3;
                            for (int i4 = digitolivrel; i4 < digito; i4++)
                            {
                                listanomes[i4] = listanomes[i4 + 1];
                            }
                            listanomes[digito] = input2;
                            break;
                        }
                    }
                }
            }
        }
        static void Show(string[] listanomes)
        {
            for (int i = 0; i < listanomes.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(listanomes[i]))
                {
                    Console.WriteLine($"{i + 1} - {listanomes[i]}");
                }
            }
        }
        static void Delete(string[] listanomes, int digitodelete, string inputregroup)
        {
                if (inputregroup == "s")
                {
                    Console.WriteLine("Vou fazer isso n pq to cansado se fodeu");
                }
                else
                {
                    listanomes[digitodelete] = null;
                    return;
                }
        }
    }
}

//Crie um programa que receba um vetor de 10 posições,
//esse programa deve ter um metodo de adicionar novos nomes.
//esse programa deve ter um metodo de adicionar nomes em indices especificos
//Esse programa deve ter um metodo de ordenar os nomes em ordem alfabetica
//esse programa deve ter um metodo para imprimir todos os nomes.
// Console.WriteLine($" 1 - {listanomes[0]} \n 2 - {listanomes[1]} \n 3 - {listanomes[2]} \n 4 - {listanomes[3]} \n 5 - 
// {listanomes[4]} \n 6 - {listanomes[5]} \n 7 - {listanomes[6]} \n 8 - {listanomes[7]} \n 9 - {listanomes[8]} \n 10 - {listanomes[9]}");