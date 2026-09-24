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

        Pokemon Falso = new Pokemon("Paloma",100, 50);
        Falso.MostrarInformacion();

        Pokemon pikachu = new Pokemon(datos[1]);
        pikachu.MostrarInformacion();

        //Prueba combate
        Arena ArenadeCombate = new Arena();

        ArenadeCombate.Enfrentar(pikachu, Falso);


        //Prueba entrenador
        Entrenador Red = new Entrenador();

        Red.Capturar(pikachu);

        //Red.CapturaSalvaje();
        Console.WriteLine($"Pokémon en el equipo: {Red.equipo.Count}");
        Red.MostrarEquipo();

        //prueba mochila
        Red.MostrarInventario();

    }
}