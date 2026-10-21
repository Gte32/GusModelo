using System.Text.Json.Nodes;

class Pokemon
{
    public string nombre;
    public List<string> tipos;

    public Estadisticas stats; //vida, ataque, curacion, nivel

    public EstadoAlterado estado;

    public Pokemon()
    {
        nombre = "Mising No";
        tipos = new List<string>();

        stats = new Estadisticas(100, 20, 0, 1);
        estado = EstadoAlterado.Normal;
    }

    public Pokemon(string nombre, int vida, int ataque)
    {
        this.nombre = nombre;
        this.tipos = new List<string>{"Normal"};
        stats = new Estadisticas(vida, ataque, 0, 1);
        estado = EstadoAlterado.Normal;
    }

    public Pokemon(PokemonJson data)
    {
        
        this.nombre = data.name;
        this.tipos = data.type;
        stats = new Estadisticas(data.hp, data.Attack, 0, 1);
        estado = EstadoAlterado.Normal;

    }
    public void MostrarInformacion()
    {
        Console.WriteLine($"=== Pokémon: {nombre} (Nivel {Nivel}) ===");
        Console.WriteLine($"Tipos: {string.Join(", ", tipos)}");
        Console.WriteLine($"Vida (HP): {stats.Vida}");
        Console.WriteLine($"Ataque: {stats.ataque}");
        Console.WriteLine("==================================\n");
    }

    public int Vida
    {
        get { return stats.Vida; }
        set { stats.Vida = value; }
    }

    public int Nivel
    {
        get { return stats.nivel; }
        set { stats.Nivel = value; }
    }




    //Pokemon ataque enviado de arena
    public virtual void Atacar(Pokemon defensor)
    {
        int daño = stats.ataque;
        int aux = defensor.stats.Vida;

        RecibirDano(defensor, daño);
        Console.WriteLine("==================================");
        Console.WriteLine($"= El atacante {this.nombre}, hizo un ataque al defensor {defensor.nombre}");
        Console.WriteLine($"= {defensor.nombre} tenia una vida inicial de {aux}");
        Console.WriteLine($"= Recibio el ataque de {this.nombre} el cual es {daño}");
        Console.WriteLine($"= Tras el ataque, el defensor {defensor.nombre} ahora tiene una vida de {defensor.stats.Vida}");
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
        int daño = stats.ataque;
        int aux = defensor.stats.Vida;
        int dañoFuego = 5;

        RecibirDano(defensor, daño + dañoFuego);
        Console.WriteLine("==================================");
        Console.WriteLine($"= El atacante {this.nombre}, hizo un ataque al defensor {defensor.nombre}");
        Console.WriteLine($"= {defensor.nombre} tenia una vida inicial de {aux}");
        Console.WriteLine($"= Recibio el ataque de {this.nombre} el cual es {daño} + el dano elemental de la clase fuego {dañoFuego} ");
        Console.WriteLine($"= Tras el ataque, el defensor {defensor.nombre} ahora tiene una vida de {defensor.stats.Vida}");
        Console.WriteLine("==================================\n");


    }

    


}

class PokemonAgua : Pokemon
{

    public PokemonAgua(string nombre, int vida, int ataque)
        : base(nombre, vida, ataque)
    {
        this.stats.curacion = 5;
    }

    // Nuevo constructor para recibir datos del JSON
    public PokemonAgua(PokemonJson data)
        : base(data)
    {
        this.stats.curacion = 5;
    }

    public override void Atacar(Pokemon defensor)
    {
        int daño = this.stats.ataque;
        int aux = defensor.stats.Vida;
        int auxV = this.stats.Vida;
        int curacionAgua = this.stats.curacion;


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