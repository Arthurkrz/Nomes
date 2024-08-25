using System;
using System.Collections.Generic;
using System.Text;

namespace Nomes
{
    class Logic
    {
        public static string[] EscolhaLista(int inputLista, string[] listaNomes, string[] listaCarros, string[] listaFrutas)
        {
            while (true)
            {
                if (inputLista == 1)
                {
                    return listaNomes;
                }
                else if (inputLista == 2)
                {
                    return listaCarros;
                }
                else if (inputLista == 3)
                {
                    return listaFrutas;
                }
            }
        }
        public static string EscolhaNomes(int inputLista)
        {
            while (true)
            {
                if (inputLista == 1)
                {
                    return "Pessoas";
                }
                else if (inputLista == 2)
                {
                    return "Carros";
                }
                else if (inputLista == 3)
                {
                    return "Frutas";
                }
                else
                {
                    Console.WriteLine("Digito inválido. Selecione a lista:");
                    inputLista = int.Parse(Console.ReadLine());
                }
            }
        }
        public static void AddNomes(string[] array, string input)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(array[i]))
                {
                    array[i] = input;
                    break;
                }
            }
        }
        public static bool ListaCheia(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(array[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool ListaVazia(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(array[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public static void AddEsp(string[] array, string input2, int digito)
        {
            if (string.IsNullOrWhiteSpace(array[digito]))
            {
                array[digito] = input2;
            }
            else
            {
                bool shiftr = false;
                for (int i = array.Length - 1; i > digito; i--)
                {
                    if (string.IsNullOrWhiteSpace(array[i]))
                    {
                        for (int j = i; j > digito; j--)
                        {
                            array[j] = array[j - 1];
                        }
                        array[digito] = input2;
                        shiftr = true;
                        break;
                    }
                }
                if (!shiftr)
                {
                    for (int i = 0; i < digito; i++)
                    {
                        if (string.IsNullOrWhiteSpace(array[i]))
                        {
                            for (int j = i; j < digito; j++)
                            {
                                array[j] = array[j + 1];
                            }
                            array[digito] = input2;
                            break;
                        }
                    }
                }
            }
        }
        public static void Show(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(array[i]))
                {
                    Console.WriteLine($"{i + 1} - {array[i]}");
                }
            }
        }
        public static void Delete(string[] array, int digitoDelete, string inputRegroup)
        {
            if (inputRegroup == "s")
            {
                for (int i = digitoDelete; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[array.Length - 1] = null;
            }
            else
            {
                array[digitoDelete] = null;
                return;
            }
        }
        public static void Clear(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = null;
            }
        }
        public static void Ordem(string[] array)
        {
            bool loop4 = true;
            while (loop4)
            {
                loop4 = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (string.IsNullOrWhiteSpace(array[i]) && !string.IsNullOrWhiteSpace(array[i + 1]))
                    {
                        string temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        loop4 = true;
                    }
                    else if (!string.IsNullOrWhiteSpace(array[i]) && !string.IsNullOrWhiteSpace(array[i + 1]))
                    {
                        int compare = String.Compare(array[i], array[i + 1]);
                        if (compare > 0)
                        {
                            string temp = array[i];
                            array[i] = array[i + 1];
                            array[i + 1] = temp;
                            loop4 = true;
                        }
                    }
                }
            }
        }
    }
}
