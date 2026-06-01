
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int> palavras = new Dictionary<string, int>();

        int totalPalavras = 0;

        Console.WriteLine("Digite o texto (linha vazia para terminar):");

        while (true)
        {
            string linha = Console.ReadLine();

            if (linha == "")
                break;

            linha = linha.ToLower();

            linha = linha.Replace(".", "");
            linha = linha.Replace(",", "");
            linha = linha.Replace("!", "");
            linha = linha.Replace("?", "");
            linha = linha.Replace(";", "");
            linha = linha.Replace(":", "");

            string[] vetor = linha.Split(' ');

            foreach (string palavra in vetor)
            {
                if (palavra == "")
                    continue;

                totalPalavras++;

                if (palavras.ContainsKey(palavra))
                {
                    palavras[palavra]++;
                }
                else
                {
                    palavras.Add(palavra, 1);
                }
            }
        }

        Console.WriteLine("\n=== Resultado ===");
        Console.WriteLine("Total de palavras: " + totalPalavras);
        Console.WriteLine("Palavras distintas: " + palavras.Count);

        Console.WriteLine("\nPalavras e suas frequências:");

        foreach (KeyValuePair<string, int> item in palavras)
        {
            Console.WriteLine(item.Key + " - " + item.Value);
        }
    }
}