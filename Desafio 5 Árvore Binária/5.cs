
using System;
public class Node
{
    public int Key { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int key)
    {
        Key = key;
        Left = null;
        Right = null;
    }
}


public class BST
{
    public Node Root { get; set; }

 
    public void Insert(int value)
    {
        Node novo = new Node(value);

        if (Root == null)
        {
            Root = novo;
            return;
        }

        Node atual = Root;

        while (true)
        {
            if (value < atual.Key)
            {
                if (atual.Left == null)
                {
                    atual.Left = novo;
                    return;
                }

                atual = atual.Left;
            }
            else
            {
                if (atual.Right == null)
                {
                    atual.Right = novo;
                    return;
                }

                atual = atual.Right;
            }
        }
    }


    public Node Search(int value)
    {
        Node atual = Root;

        while (atual != null)
        {
            if (value == atual.Key)
            {
                return atual;
            }
            else if (value < atual.Key)
            {
                atual = atual.Left;
            }
            else
            {
                atual = atual.Right;
            }
        }

        return null;
    }
}

class Program
{
    static void Main()
    {
        BST arvore = new BST();

        arvore.Insert(50);
        arvore.Insert(30);
        arvore.Insert(70);
        arvore.Insert(20);
        arvore.Insert(40);
        arvore.Insert(60);
        arvore.Insert(80);

        Node encontrado = arvore.Search(40);

        if (encontrado != null)
            Console.WriteLine("Valor encontrado: " + encontrado.Key);
        else
            Console.WriteLine("Valor não encontrado");
    }
}