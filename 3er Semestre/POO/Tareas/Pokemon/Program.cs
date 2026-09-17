using System.Globalization;
using System.Text.Json;

class Program
{
    static void Main()
    {   
        string json = File.ReadAllText("pokemon.json");
        List<PokemonJson> datos = JsonSerializer.Deserialize<List<PokemonJson>>(json);


        Pokemon Default = new Pokemon();
        Default.MostrarInformacion();

        Pokemon Falso = new Pokemon("Paloma",100, 50);
        Falso.MostrarInformacion();

        Pokemon pikachu = new Pokemon(datos[1]);
        pikachu.MostrarInformacion();
    }
}