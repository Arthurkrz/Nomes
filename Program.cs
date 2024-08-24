using System;


namespace Nomes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] listaNomes = new string[10];
            string[] listaCarros = new string[10];
            string[] listaFrutas = new string[10];
            bool controle = true;
            while (controle)
            {
                Console.WriteLine("Bem vindo à biblioteca de listas!\n \nSelecione a lista a ser manipulada:\n1 - Pessoas;\n2 - Carros;\n3 - Frutas.");
                int inputLista = int.Parse(Console.ReadLine());
                string listaEscolhida = Logic.EscolhaLista(inputLista);
                Console.WriteLine($"Bem vindo à lista de {listaEscolhida}!\n \nDigite o índice da operação a ser realizada: \n 1 - Adicionar nomes; \n 2 - Adicionar nomes em índices específicos; \n 3 - Mostrar todos os nomes;" +
                " \n 4 - Remover um nome; \n 5 - Reagrupar nomes em ordem alfabética; \n 6 - Sair.");
                int digitoInicio = int.Parse(Console.ReadLine());
                switch (digitoInicio)
                {
                    case 1:
                        bool loop = true;
                        while (loop)
                        {
                            if (ListaCheia(listaNomes))
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
                                AddNomes(listaNomes, input);
                                Console.Clear();
                            }
                        }
                        break;
                    case 2:
                        bool loop2 = true;
                        while (loop2)
                        {
                            if (ListaCheia(listaNomes))
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
                                string inputDigito = Console.ReadLine();
                                int digito = int.Parse(inputDigito) - 1;
                                AddEsp(listaNomes, input2, digito);
                                Console.Clear();
                            }
                        }
                        break;
                    case 3:
                        if (ListaVazia(listaNomes))
                        {
                            Console.Clear();
                            Console.WriteLine("A lista está vazia. \n ");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Show(listaNomes);
                            Console.WriteLine(" ");
                        }
                        break;
                    case 4:
                        bool loop3 = true;
                        while (loop3)
                        {
                            if (ListaVazia(listaNomes))
                            {
                                Console.Clear();
                                Console.WriteLine("A lista está vazia. \n ");
                                break;
                            }
                            Console.WriteLine("Digite o índice do nome a ser removido (1-10) ou pressione 'e' para sair ou pressione 'x' para limpar a lista:");
                            string inputDelete = Console.ReadLine();
                            if (inputDelete.ToLower() == "e")
                            {
                                Console.Clear();
                                break;
                            }
                            if (inputDelete.ToLower() == "x")
                            {
                                Clear(listaNomes);
                                Console.Clear();
                                Console.WriteLine("Todos os nomes foram removidos. \n ");
                                break;
                            }
                            if (inputDelete.ToLower() != "e" || inputDelete.ToLower() != "x")
                            {
                                int digitoDelete = int.Parse(inputDelete) - 1;
                                Console.WriteLine("Deseja reagrupar os nomes ('s'/'n')?");
                                string inputregroup = Console.ReadLine();
                                Delete(listaNomes, digitoDelete, inputregroup, inputDelete);
                                Console.Clear();
                                Console.WriteLine("O nome foi removido com sucesso. \n ");
                            }
                        }
                        break;
                    case 5:
                        if (ListaVazia(listaNomes))
                        {
                            Console.Clear();
                            Console.WriteLine("A lista está vazia.\n");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Ordem(listaNomes);
                            Console.WriteLine("A lista foi reorganizada.\n");
                        }
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Dígito inválido.\n");
                        break;
                }
            }
        }
        static void AddNomes(string[] listaNomes, string input)
        {
            for (int i = 0; i < listaNomes.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(listaNomes[i]))
                {
                    listaNomes[i] = input;
                    break;
                }
            }
        }
        public static bool ListaCheia(string[] listaNomes)
        {
            for (int i = 0; i < listaNomes.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(listaNomes[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool ListaVazia(string[] listaNomes)
        {
            for (int i = 0; i < listaNomes.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(listaNomes[i]))
                {
                    return false;
                }
            }
            return true;
        }
        static void AddEsp(string[] listaNomes, string input2, int digito)
        {
            if (string.IsNullOrWhiteSpace(listaNomes[digito]))
            {
                listaNomes[digito] = input2;
            }
            else
            {
                bool shiftr = false;
                for (int i = listaNomes.Length - 1; i > digito; i--)
                {
                    if (string.IsNullOrWhiteSpace(listaNomes[i]))
                    {
                        for (int j = i; j > digito; j--)
                        {
                            listaNomes[j] = listaNomes[j - 1];
                        }
                        listaNomes[digito] = input2;
                        shiftr = true;
                        break;
                    }
                }
                if (!shiftr)
                {
                    for (int i = 0; i < digito; i++)
                    {
                        if (string.IsNullOrWhiteSpace(listaNomes[i]))
                        {
                            for (int j = i; j < digito; j++)
                            {
                                listaNomes[j] = listaNomes[j + 1];
                            }
                            listaNomes[digito] = input2;
                            break;
                        }
                    }
                }
            }
        }
        static void Show(string[] listaNomes)
        {
            for (int i = 0; i < listaNomes.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(listaNomes[i]))
                {
                    Console.WriteLine($"{i + 1} - {listaNomes[i]}");
                }
            }
        }
        static void Delete(string[] listaNomes, int digitoDelete, string inputRegroup, string inputDelete)
        {
            if (inputRegroup == "s")
            {
                for (int i = digitoDelete; i < listaNomes.Length - 1; i++)
                {
                    listaNomes[i] = listaNomes[i + 1];
                }
                listaNomes[listaNomes.Length - 1] = null;
            }
            else
            {
                listaNomes[digitoDelete] = null;
                return;
            }
        }
        static void Clear(string[] listaNomes)
        {
            for (int i = 0; i < listaNomes.Length; i++)
            {
                listaNomes[i] = null;
            }
        }
        static void Ordem(string[] listaNomes)
        {
            bool loop4 = true;
            while (loop4)
            {
                loop4 = false;
                for (int i = 0; i < listaNomes.Length - 1; i++)
                {
                    if (string.IsNullOrWhiteSpace(listaNomes[i]) && !string.IsNullOrWhiteSpace(listaNomes[i + 1]))
                    {
                        string temp = listaNomes[i];
                        listaNomes[i] = listaNomes[i + 1];
                        listaNomes[i + 1] = temp;
                        loop4 = true;
                    }
                    else if (!string.IsNullOrWhiteSpace(listaNomes[i]) && !string.IsNullOrWhiteSpace(listaNomes[i + 1]))
                    {
                        int compare = String.Compare(listaNomes[i], listaNomes[i + 1]);
                        if (compare > 0)
                        {
                            string temp = listaNomes[i];
                            listaNomes[i] = listaNomes[i + 1];
                            listaNomes[i + 1] = temp;
                            loop4 = true;
                        }
                    }
                }
            }
        }
    }
}