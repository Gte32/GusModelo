using System.Text.Json.Nodes;

class Pokemon
{
    public string nombre;
    public List<string> tipos;
    private int vida;
    private int vidaMaxima;
    public int ataque;
    private int nivel;



    public Pokemon()
    {
        nombre = "Mising No";
        tipos = new List<string>();
        vidaMaxima = 100;
        Vida = 100;
        ataque = 20;
        Nivel = 1;
    }

    public Pokemon(string nombre, int vida, int ataque)
    {
        this.nombre = nombre;
        this.tipos = new List<string>{"Normal"};
        vidaMaxima = vida;
        this.Vida = vida;
        this.ataque = ataque;
        this.Nivel = 1;
    }

    public Pokemon(PokemonJson data)
    {
        this.nombre = data.name;
        this.tipos = data.type;
        vidaMaxima = data.hp; // importante vaya antes de Vida
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
            vida = Math.Clamp(value, 0, vidaMaxima);
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




    //Pokemon ataque enviado de arena
    public virtual void Atacar(Pokemon defensor)
    {
        int daño = this.ataque;
        int aux = defensor.Vida;

        RecibirDano(defensor, daño);
        Console.WriteLine("==================================");
        Console.WriteLine($"= El atacante {this.nombre}, hizo un ataque al defensor {defensor.nombre}");
        Console.WriteLine($"= {defensor.nombre} tenia una vida inicial de {aux}");
        Console.WriteLine($"= Recibio el ataque de {this.nombre} el cual es {daño}");
        Console.WriteLine($"= Tras el ataque, el defensor {defensor.nombre} ahora tiene una vida de {defensor.Vida}");
        Console.WriteLine("==================================\n");


    }

    protected void RecibirDano(Pokemon herido, int daño)
    {
        herido.Vida -= daño;
    }

    protected void Curarse(int curacion)
    {
        this.Vida += curacion;
    }


}

class PokemonFuego : Pokemon
{

    public PokemonFuego(string nombre, int vida, int ataque)
        : base(nombre, vida, ataque)
    {
        
    }

    // Nuevo constructor para recibir datos del JSON
    public PokemonFuego(PokemonJson data)
        : base(data)
    {
        
    }

    public override void Atacar(Pokemon defensor)
    {
        int daño = this.ataque;
        int aux = defensor.Vida;
        int dañoFuego = 5;

        RecibirDano(defensor, daño + dañoFuego);
        Console.WriteLine("==================================");
        Console.WriteLine($"= El atacante {this.nombre}, hizo un ataque al defensor {defensor.nombre}");
        Console.WriteLine($"= {defensor.nombre} tenia una vida inicial de {aux}");
        Console.WriteLine($"= Recibio el ataque de {this.nombre} el cual es {daño}, + el dano elemental de la clase fuego {dañoFuego} ");
        Console.WriteLine($"= Tras el ataque, el defensor {defensor.nombre} ahora tiene una vida de {defensor.Vida}");
        Console.WriteLine("==================================\n");


    }

    


}

class PokemonAgua : Pokemon
{

    public PokemonAgua(string nombre, int vida, int ataque)
        : base(nombre, vida, ataque)
    {
        
    }

    // Nuevo constructor para recibir datos del JSON
    public PokemonAgua(PokemonJson data)
        : base(data)
    {
 
    }

    public override void Atacar(Pokemon defensor)
    {
        int daño = this.ataque;
        int aux = defensor.Vida;
        int auxV = this.Vida;
        int curacionAgua = 5;

        RecibirDano(defensor, daño);
        Curarse(curacionAgua);
        Console.WriteLine("==================================");
        Console.WriteLine($"= El atacante {this.nombre}, hizo un ataque al defensor {defensor.nombre}");
        Console.WriteLine($"= Por ser un pokemon de agua, el pokemon atacante {this.nombre}, se curo la cantidad de {curacionAgua} ");
        Console.WriteLine($"= Se curo a su vida de {auxV}, y ahora tiene {this.Vida}");
        Console.WriteLine($"= {defensor.nombre} tenia una vida inicial de {aux}");
        Console.WriteLine($"= Recibio el ataque de {this.nombre} el cual es {daño} ");
        Console.WriteLine($"= Tras el ataque, el defensor {defensor.nombre} ahora tiene una vida de {defensor.Vida}");
        Console.WriteLine("==================================\n");


    }


}