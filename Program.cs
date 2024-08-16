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
                Console.WriteLine("Digite o índice da operação a ser realizada: \n 1 - Adicionar nomes; \n 2 - Adicionar nomes em índices específicos; \n 3 - Mostrar todos os nomes;" +
                " \n 4 - Remover um nome; \n 5 - Reagrupar nomes em ordem alfabética; \n 6 - Sair.");
                string inputinicio = Console.ReadLine();
                int digitoinicio = int.Parse(inputinicio);
                switch (digitoinicio)
                {
                    case 1:
                        bool loop = true;
                        while (loop)
                        {
                            if (ListaCheia(listanomes))
                            {
                                Console.Clear();
                                Console.WriteLine("A lista de nomes está cheia. \n ");
                                break;
                            }
                            Console.Clear();
                            Console.WriteLine("Digite o nome a ser adicionado ou pressione 'e' para retornar ao menu inicial:");
                            string input = Console.ReadLine();
                            if (input.ToLower() == "e")
                            {
                                loop = false;
                                Console.Clear();
                            }
                            else
                            {
                                AddNomes(listanomes, input);
                                Console.Clear();
                            }
                        }
                        break;
                    case 2:
                        bool loop2 = true;
                        while (loop2)
                        {
                            if (ListaCheia(listanomes))
                            {
                                Console.Clear();
                                Console.WriteLine("A lista está cheia. \n ");
                                break;
                            }
                            Console.Clear();
                            Console.WriteLine("Digite o nome a ser adicionado na posição específica ou pressione 'e' para retornar ao menu inicial:");
                            string input2 = Console.ReadLine();
                            if (input2.ToLower() == "e")
                            {
                                loop2 = false;
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Digite o índice do nome a ser adicionado (1-10):");
                                string inputdigito = Console.ReadLine();
                                int digito = int.Parse(inputdigito) - 1;
                                AddEsp(listanomes, input2, digito);
                                Console.Clear();
                            }
                        }
                        break;
                    case 3:
                        if (ListaVazia(listanomes))
                        {
                            Console.Clear();
                            Console.WriteLine("A lista está vazia. \n ");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Show(listanomes);
                            Console.WriteLine(" ");
                        }
                        break;
                    case 4:
                        bool loop3 = true;
                        while (loop3)
                        {
                            if (ListaVazia(listanomes))
                            {
                                Console.Clear();
                                Console.WriteLine("A lista está vazia. \n ");
                                break;
                            }
                            Console.WriteLine("Digite o índice do nome a ser removido (1-10) ou pressione 'e' para sair ou pressione 'x' para limpar a lista:");
                            string inputdelete = Console.ReadLine();
                            if (inputdelete.ToLower() == "e")
                            {
                                Console.Clear();
                                break;
                            }
                            if (inputdelete.ToLower() == "x")
                            {
                                Clear(listanomes, inputdelete);
                                Console.Clear();
                                Console.WriteLine("Todos os nomes foram removidos. \n ");
                                break;
                            }
                            if (inputdelete.ToLower() != "e" || inputdelete.ToLower() != "x")
                            {
                                int digitodelete = int.Parse(inputdelete) - 1;
                                Console.WriteLine("Deseja reagrupar os nomes ('s'/'n')?");
                                string inputregroup = Console.ReadLine();
                                Delete(listanomes, digitodelete, inputregroup, inputdelete);
                                Console.Clear();
                                Console.WriteLine("O nome foi removido com sucesso. \n ");
                            }
                        }
                        break;
                    case 5:
                        if (ListaVazia(listanomes))
                        {
                            Console.Clear();
                            Console.WriteLine("A lista está vazia. \n ");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Ordem(listanomes);
                            Console.WriteLine("A lista foi reorganizada. \n ");
                        }
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Dígito inválido. \n ");
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
                for (int i = listanomes.Length - 1; i > digito; i--)
                {
                    if (string.IsNullOrWhiteSpace(listanomes[i]))
                    {
                        for (int j = i; j > digito; j--)
                        {
                            listanomes[j] = listanomes[j - 1];
                        }
                        listanomes[digito] = input2;
                        shiftr = true;
                        break;
                    }
                }
                if (!shiftr)
                {
                    for (int i = 0; i < digito; i++)
                    {
                        if (string.IsNullOrWhiteSpace(listanomes[i]))
                        {
                            for (int j = i; j < digito; j++)
                            {
                                listanomes[j] = listanomes[j + 1];
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
        static void Delete(string[] listanomes, int digitodelete, string inputregroup, string inputdelete)
        {
            if (inputregroup == "s")
            {
                for (int i = digitodelete; i < listanomes.Length - 1; i++)
                {
                    listanomes[i] = listanomes[i + 1];
                }
                listanomes[listanomes.Length - 1] = null;
            }
            else
            {
                listanomes[digitodelete] = null;
                return;
            }
        }
        static void Clear(string[] listanomes, string inputdelete)
        {
            for (int i = 0; i < listanomes.Length; i++)
            {
                listanomes[i] = null;
            }
        }
        static void Ordem(string[] listanomes)
        {
            bool loop4 = true;
            while (loop4)
            {
                loop4 = false;
                for (int i = 0; i < listanomes.Length - 1; i++)
                {
                    if (string.IsNullOrWhiteSpace(listanomes[i]) && !string.IsNullOrWhiteSpace(listanomes[i + 1]))
                    {
                        string temp = listanomes[i];
                        listanomes[i] = listanomes[i + 1];
                        listanomes[i + 1] = temp;
                        loop4 = true;
                    }
                    else if (!string.IsNullOrWhiteSpace(listanomes[i]) && !string.IsNullOrWhiteSpace(listanomes[i + 1]))
                    {
                        int compare = String.Compare(listanomes[i], listanomes[i + 1]);
                        if (compare > 0)
                        {
                            string temp = listanomes[i];
                            listanomes[i] = listanomes[i + 1];
                            listanomes[i + 1] = temp;
                            loop4 = true;
                        }
                    }
                }
            }
        }
    }
}