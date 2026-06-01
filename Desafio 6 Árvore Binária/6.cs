
using System;

public class Node {
    public int Key { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int key) {
        Key = key;
        Left = null;
        Right = null;
    }
}

public class BST {

    public Node Root { get; set; }

    public void Insert(int value) {
        Root = InsertRec(Root, value);
    }

    private Node InsertRec(Node node, int value) {
        if (node == null)
            return new Node(value);

        if (value < node.Key)
            node.Left = InsertRec(node.Left, value);
        else if (value > node.Key)
            node.Right = InsertRec(node.Right, value);

        return node;
    }

    public Node Search(int value) {
        return SearchRec(Root, value);
    }

    private Node SearchRec(Node node, int value) {
        if (node == null || node.Key == value)
            return node;

        if (value < node.Key)
            return SearchRec(node.Left, value);

        return SearchRec(node.Right, value);
    }

    public Node Maximo() {
        if (Root == null)
            return null;

        Node atual = Root;

        while (atual.Right != null)
            atual = atual.Right;

        return atual;
    }

    public Node MaximoRec() {
        return MaximoRec(Root);
    }

    private Node MaximoRec(Node node) {
        if (node == null || node.Right == null)
            return node;

        return MaximoRec(node.Right);
    }

    public Node Minimo() {
        if (Root == null)
            return null;

        Node atual = Root;

        while (atual.Left != null)
            atual = atual.Left;

        return atual;
    }

    public Node MinimoRec() {
        return MinimoRec(Root);
    }

    private Node MinimoRec(Node node) {
        if (node == null || node.Left == null)
            return node;

        return MinimoRec(node.Left);
    }

    public void PrintInOrder() {
        PrintInOrderRec(Root);
        Console.WriteLine();
    }

    private void PrintInOrderRec(Node node) {
        if (node == null)
            return;

        PrintInOrderRec(node.Left);
        Console.Write(node.Key + " ");
        PrintInOrderRec(node.Right);
    }

    public void CoolPrint() {
        CoolPrintRec(Root, 0);
    }

    private void CoolPrintRec(Node node, int nivel) {
        if (node == null)
            return;

        Console.WriteLine(new string(' ', nivel * 4) + node.Key);

        CoolPrintRec(node.Left, nivel + 1);
        CoolPrintRec(node.Right, nivel + 1);
    }
}

public class Program {
    public static void Main(string[] args) {

        BST bst = new BST();

        bst.Insert(15);
        bst.Insert(10);
        bst.Insert(8);
        bst.Insert(12);
        bst.Insert(20);
        bst.Insert(21);

        Console.WriteLine("In-order traversal:");
        bst.PrintInOrder();

        Console.WriteLine("\nMenor valor: " + bst.Minimo().Key);
        Console.WriteLine("Maior valor: " + bst.Maximo().Key);

        Console.WriteLine("\nBusca 12:");
        Node encontrado = bst.Search(12);

        if (encontrado != null)
            Console.WriteLine("Encontrado!");
        else
            Console.WriteLine("Não encontrado!");

        Console.WriteLine("\nVisualização da árvore:");
        bst.CoolPrint();
    }
}