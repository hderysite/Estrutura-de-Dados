
using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, List<string>> grafo =
        new Dictionary<string, List<string>>();

    static void Main()
    {
        CriarMapa();

        int opcao;

        do
        {
            Console.WriteLine("\n=== Bora Viajar! ===");
            Console.WriteLine("1 - Listar cidades");
            Console.WriteLine("2 - Conexão direta");
            Console.WriteLine("3 - Existe rota? (DFS)");
            Console.WriteLine("4 - Menor rota (BFS)");
            Console.WriteLine("5 - Sair");
            Console.Write("Opção: ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    ListarCidades();
                    break;

                case 2:
                    VerificarConexao();
                    break;

                case 3:
                    TestarDFS();
                    break;

                case 4:
                    MenorRota();
                    break;

                case 5:
                    Console.WriteLine("Boa viagem!");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

        } while (opcao != 5);
    }

    static void CriarMapa()
    {
        grafo["São Paulo"] = new List<string>
        {
            "Rio de Janeiro",
            "Curitiba",
            "Belo Horizonte"
        };

        grafo["Rio de Janeiro"] = new List<string>
        {
            "São Paulo",
            "Belo Horizonte",
            "Vitória"
        };

        grafo["Belo Horizonte"] = new List<string>
        {
            "São Paulo",
            "Rio de Janeiro",
            "Brasília"
        };

        grafo["Curitiba"] = new List<string>
        {
            "São Paulo",
            "Florianópolis"
        };

        grafo["Florianópolis"] = new List<string>
        {
            "Curitiba",
            "Porto Alegre"
        };

        grafo["Porto Alegre"] = new List<string>
        {
            "Florianópolis"
        };

        grafo["Brasília"] = new List<string>
        {
            "Belo Horizonte",
            "Goiânia"
        };

        grafo["Goiânia"] = new List<string>
        {
            "Brasília"
        };

        grafo["Vitória"] = new List<string>
        {
            "Rio de Janeiro"
        };

        grafo["Salvador"] = new List<string>
        {
            "Recife"
        };

        grafo["Recife"] = new List<string>
        {
            "Salvador",
            "Fortaleza"
        };

        grafo["Fortaleza"] = new List<string>
        {
            "Recife"
        };
    }

    static void ListarCidades()
    {
        Console.WriteLine("\nCidades e conexões:");

        foreach (var cidade in grafo)
        {
            Console.Write(cidade.Key + ": ");

            foreach (string vizinho in cidade.Value)
            {
                Console.Write(vizinho + " ");
            }

            Console.WriteLine();
        }
    }

    static void VerificarConexao()
    {
        Console.Write("Cidade 1: ");
        string c1 = Console.ReadLine();

        Console.Write("Cidade 2: ");
        string c2 = Console.ReadLine();

        if (grafo.ContainsKey(c1) &&
            grafo[c1].Contains(c2))
        {
            Console.WriteLine("Existe conexão direta!");
        }
        else
        {
            Console.WriteLine("Não existe conexão direta.");
        }
    }

    static void TestarDFS()
    {
        Console.Write("Origem: ");
        string origem = Console.ReadLine();

        Console.Write("Destino: ");
        string destino = Console.ReadLine();

        HashSet<string> visitados =
            new HashSet<string>();

        Console.Write("DFS visitando: ");

        bool encontrou =
            DFS(origem, destino, visitados);

        Console.WriteLine();

        if (encontrou)
            Console.WriteLine("Rota encontrada!");
        else
            Console.WriteLine("Rota NÃO encontrada.");
    }

    static bool DFS(string atual,
                    string destino,
                    HashSet<string> visitados)
    {
        Console.Write(atual + " ");

        if (atual == destino)
            return true;

        visitados.Add(atual);

        foreach (string vizinho in grafo[atual])
        {
            if (!visitados.Contains(vizinho))
            {
                if (DFS(vizinho,
                        destino,
                        visitados))
                {
                    return true;
                }
            }
        }

        return false;
    }

    static void MenorRota()
    {
        Console.Write("Origem: ");
        string origem = Console.ReadLine();

        Console.Write("Destino: ");
        string destino = Console.ReadLine();

        Queue<string> fila =
            new Queue<string>();

        HashSet<string> visitados =
            new HashSet<string>();

        Dictionary<string, string> pai =
            new Dictionary<string, string>();

        fila.Enqueue(origem);
        visitados.Add(origem);

        bool encontrou = false;

        while (fila.Count > 0)
        {
            string atual = fila.Dequeue();

            if (atual == destino)
            {
                encontrou = true;
                break;
            }

            foreach (string vizinho in grafo[atual])
            {
                if (!visitados.Contains(vizinho))
                {
                    visitados.Add(vizinho);
                    pai[vizinho] = atual;
                    fila.Enqueue(vizinho);
                }
            }
        }

        if (!encontrou)
        {
            Console.WriteLine("Não existe rota.");
            return;
        }

        List<string> caminho =
            new List<string>();

        string cidade = destino;

        while (cidade != origem)
        {
            caminho.Add(cidade);
            cidade = pai[cidade];
        }

        caminho.Add(origem);
        caminho.Reverse();

        Console.WriteLine("\nMenor rota:");

        for (int i = 0; i < caminho.Count; i++)
        {
            Console.Write(caminho[i]);

            if (i < caminho.Count - 1)
                Console.Write(" -> ");
        }

        Console.WriteLine();
        Console.WriteLine("Paradas: " + (caminho.Count - 1));
    }
}