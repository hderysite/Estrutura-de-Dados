using System;
using System.Collections.Generic;

class Pokemon
{
    public string Nome;
    public int Vida;
    public int Ataque;
    public int Defesa;

    public Pokemon(string nome, int vida, int ataque, int defesa)
    {
        Nome = nome;
        Vida = vida;
        Ataque = ataque;
        Defesa = defesa;
    }

    public virtual void Atacar(Pokemon alvo)
    {
        int dano = Ataque - alvo.Defesa;

        if (dano < 1)
            dano = 1;

        alvo.Vida -= dano;

        Console.WriteLine($"{Nome} atacou {alvo.Nome} e causou {dano} de dano.");
    }

    public void ExibirStatus()
    {
        Console.WriteLine($"{Nome} - Vida: {Vida}");
    }
}

class PokemonFogo : Pokemon
{
    public PokemonFogo(string nome, int vida, int ataque, int defesa)
        : base(nome, vida, ataque, defesa) { }

    public override void Atacar(Pokemon alvo)
    {
        int dano = Ataque - alvo.Defesa + 2;

        if (dano < 1)
            dano = 1;

        alvo.Vida -= dano;

        Console.WriteLine($"{Nome} (Fogo) causou {dano} de dano.");
    }
}

class PokemonAgua : Pokemon
{
    public PokemonAgua(string nome, int vida, int ataque, int defesa)
        : base(nome, vida, ataque, defesa) { }

    public override void Atacar(Pokemon alvo)
    {
        base.Atacar(alvo);
        Vida += 2;

        Console.WriteLine($"{Nome} recuperou 2 de vida.");
    }
}

class Treinador
{
    public string Nome;
    public List<Pokemon> Pokemons = new List<Pokemon>();

    public Treinador(string nome)
    {
        Nome = nome;
    }

    public void AdicionarPokemon(Pokemon p)
    {
        Pokemons.Add(p);
    }
}

class Program
{
    static void Main()
    {
        Treinador ash = new Treinador("Ash");
        Treinador misty = new Treinador("Misty");

        ash.AdicionarPokemon(new PokemonFogo("Charmander", 20, 8, 2));
        misty.AdicionarPokemon(new PokemonAgua("Squirtle", 20, 7, 2));

        Pokemon p1 = ash.Pokemons[0];
        Pokemon p2 = misty.Pokemons[0];

        while (p1.Vida > 0 && p2.Vida > 0)
        {
            p1.Atacar(p2);

            if (p2.Vida <= 0)
                break;

            p2.Atacar(p1);

            Console.WriteLine();
            p1.ExibirStatus();
            p2.ExibirStatus();
            Console.WriteLine();
        }

        if (p1.Vida > 0)
            Console.WriteLine($"{p1.Nome} venceu!");
        else
            Console.WriteLine($"{p2.Nome} venceu!");
    }
}