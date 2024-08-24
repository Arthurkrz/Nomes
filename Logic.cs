using System;
using System.Collections.Generic;
using System.Text;

namespace Nomes
{
    class Logic
    {
        public static string EscolhaLista(int inputLista)
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
    }
}
