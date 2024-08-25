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
                Console.Clear();
                bool controle2 = true;
                while (controle2)
                {
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
                                Console.WriteLine("Digite o nome a ser adicionado:");
                                string input = Console.ReadLine();
                                Logic.AddNomes(listaEscolhida, input);
                                Console.Clear();
                                Console.WriteLine("Gostaria de adicionar outro nome ('s'/'n')?");
                                string inputdnv = Console.ReadLine();
                                if (inputdnv.ToLower() == "s")
                                {
                                    Console.Clear();
                                }
                                else if (inputdnv.ToLower() == "n")
                                {
                                    loop = false;
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Resposta inválida.");
                                    loop = false;
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
                                Console.WriteLine("Digite o nome a ser adicionado na posição específica:");
                                string input2 = Console.ReadLine();
                                Console.WriteLine("Digite o índice do nome a ser adicionado (1-10):");
                                string inputDigito = Console.ReadLine();
                                int digito = int.Parse(inputDigito) - 1;
                                Logic.AddEsp(listaEscolhida, input2, digito);
                                Console.Clear();
                                Console.WriteLine("Gostaria de adicionar outro nome ('s'/'n')?");
                                string inputdnv2 = Console.ReadLine();
                                if (inputdnv2.ToLower() == "s")
                                {
                                    Console.Clear();
                                }
                                else if (inputdnv2.ToLower() == "n")
                                {
                                    loop2 = false;
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Resposta inválida.");
                                    loop2 = false;
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
                                Console.Clear();
                                Console.WriteLine("Digite o índice do nome a ser removido (1-10) ou pressione 'x' para limpar a lista:");
                                string inputDelete = Console.ReadLine();
                                if (inputDelete.ToLower() == "x")
                                {
                                    Logic.Clear(listaEscolhida);
                                    Console.Clear();
                                    Console.WriteLine("Todos os nomes foram removidos.\n");
                                    break;
                                }
                                else
                                {
                                    int digitoDelete = int.Parse(inputDelete) - 1;
                                    Console.Clear();
                                    Console.WriteLine("Deseja reagrupar os nomes ('s'/'n')?");
                                    string inputregroup = Console.ReadLine();
                                    Logic.Delete(listaEscolhida, digitoDelete, inputregroup);
                                    Console.Clear();
                                    Console.WriteLine("O nome foi removido com sucesso.\n ");
                                    Console.WriteLine("Gostaria de remover outro nome ('s'/'n')?");
                                    string inputdnv2 = Console.ReadLine();
                                    if (inputdnv2.ToLower() == "s")
                                    {
                                        Console.Clear();
                                    }
                                    else if (inputdnv2.ToLower() == "n")
                                    {
                                        Console.Clear();
                                        loop3 = false;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Resposta inválida.");
                                        break;
                                    }
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
                            Console.Clear();
                            controle2 = false;
                            break;
                        case 7:
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
}