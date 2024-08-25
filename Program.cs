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
                string nomeLista = Logic.EscolhaNomes(inputLista);
                string[] listaEscolhida = Logic.EscolhaLista(inputLista, listaNomes, listaCarros, listaFrutas);
                Console.WriteLine($"Bem vindo à lista de {nomeLista}!\n \nDigite o índice da operação a ser realizada: \n1 - Adicionar nomes; \n2 - Adicionar nomes em índices específicos;\n" +
                    $"3 - Mostrar todos os nomes; \n4 - Remover um nome; \n5 - Reagrupar nomes em ordem alfabética; \n6 - Trocar de lista; \n7 - Sair.");
                int digitoInicio = int.Parse(Console.ReadLine());
                switch (digitoInicio)
                {
                    case 1:
                        bool loop = true;
                        while (loop)
                        {
                            if (Logic.ListaCheia(listaEscolhida))
                            {
                                Console.Clear();
                                Console.WriteLine("A lista de nomes está cheia.\n");
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
                                Logic.AddNomes(listaEscolhida, input);
                                Console.Clear();
                            }
                        }
                        break;
                    case 2:
                        bool loop2 = true;
                        while (loop2)
                        {
                            if (Logic.ListaCheia(listaEscolhida))
                            {
                                Console.Clear();
                                Console.WriteLine("A lista está cheia.\n");
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
                                Logic.AddEsp(listaEscolhida, input2, digito);
                                Console.Clear();
                            }
                        }
                        break;
                    case 3:
                        if (Logic.ListaVazia(listaEscolhida))
                        {
                            Console.Clear();
                            Console.WriteLine("A lista está vazia.\n");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Logic.Show(listaEscolhida);
                            Console.WriteLine(" ");
                        }
                        break;
                    case 4:
                        bool loop3 = true;
                        while (loop3)
                        {
                            if (Logic.ListaVazia(listaEscolhida))
                            {
                                Console.Clear();
                                Console.WriteLine("A lista está vazia.\n");
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
                                Logic.Clear(listaEscolhida);
                                Console.Clear();
                                Console.WriteLine("Todos os nomes foram removidos.\n");
                                break;
                            }
                            if (inputDelete.ToLower() != "e" || inputDelete.ToLower() != "x")
                            {
                                int digitoDelete = int.Parse(inputDelete) - 1;
                                Console.WriteLine("Deseja reagrupar os nomes ('s'/'n')?");
                                string inputregroup = Console.ReadLine();
                                Logic.Delete(listaEscolhida, digitoDelete, inputregroup, inputDelete);
                                Console.Clear();
                                Console.WriteLine("O nome foi removido com sucesso. \n ");
                            }
                        }
                        break;
                    case 5:
                        if (Logic.ListaVazia(listaEscolhida))
                        {
                            Console.Clear();
                            Console.WriteLine("A lista está vazia.\n");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Logic.Ordem(listaEscolhida);
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
    }
}