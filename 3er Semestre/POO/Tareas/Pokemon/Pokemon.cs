using System.Text.Json.Nodes;

class Pokemon
{
    public string nombre;
    public List<string> tipos;
    private int vida;
    public int ataque;
    private int nivel;



    public Pokemon()
    {
        nombre = "Mising No";
        tipos = new List<string>();
        Vida = 100;
        ataque = 20;
        Nivel = 1;
    }

    public Pokemon(string nombre, int vida, int ataque)
    {
        this.nombre = nombre;
        this.tipos = new List<string>{"Normal"};
        this.Vida = vida;
        this.ataque = ataque;
        this.Nivel = 1;
    }

    public Pokemon(PokemonJson data)
    {
        this.nombre = data.name;
        this.tipos = data.type;
        this.Vida = data.hp;
        this.ataque = data.Attack;
        this.Nivel = 1;
        
    }
    public void MostrarInformacion()
    {
        Console.WriteLine($"=== Pokémon: {nombre} (Nivel {Nivel}) ===");
        Console.WriteLine($"Tipos: {string.Join(", ", tipos)}");
        Console.WriteLine($"Vida (HP): {Vida}");
        Console.WriteLine($"Ataque: {ataque}");
        Console.WriteLine("==================================\n");
    }

    public int Vida
    {
        get{ return vida; }
        set
        {
            vida = Math.Max(0, value);
        }
    }

    public int Nivel
    {
        get{ return nivel; }
        set
        {
            nivel = Math.Clamp(value, nivel, 100);
        }
    }

}