using System.Globalization;
using System.Text.Json;

class Program
{
    static void Main()
    {   

        //Prueba Json
        string json = File.ReadAllText("pokemon.json");
        List<PokemonJson> datos = JsonSerializer.Deserialize<List<PokemonJson>>(json);

        //Prueba creacion pokemon
        Pokemon Default = new Pokemon();
        Default.MostrarInformacion();

        Pokemon Falso = new Pokemon("Paloma",100, 20);
        Falso.MostrarInformacion();

        PokemonFuego charmander = new PokemonFuego(datos[4]);
        charmander.MostrarInformacion();

        PokemonAgua squirtle = new PokemonAgua(datos[9]);
        squirtle.MostrarInformacion();

        //Prueba combate
        //estan muriendo porque estan literal aplicando su ataque completo al otro
        squirtle.Atacar(Falso);
        squirtle.Atacar(Default);
        Falso.Atacar(squirtle);
        squirtle.Atacar(Falso);



        //Prueba entrenador
        Entrenador Red = new Entrenador();

        Red.Capturar(charmander);

        //Red.CapturaSalvaje();
        Console.WriteLine($"Pokémon en el equipo: {Red.equipo.Count}");
        Red.MostrarEquipo();

        //prueba mochila
        Red.MostrarInventario();

    }
}