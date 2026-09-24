using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

class Entrenador
{
    public string name;
    public List<Pokemon> equipo;

    private List<PokemonJson> datos;

    public Mochila miInventario;

    public void Capturar(Pokemon nuevo)
    {
        equipo.Add(nuevo);
    }

    public Entrenador()
    {
        string json = File.ReadAllText("pokemon.json");
        datos = JsonSerializer.Deserialize<List<PokemonJson>>(json);

        equipo = new List<Pokemon>();

        miInventario = new Mochila();
    }
    /*
    public void CapturaSalvaje()
    {
        Random random = new Random();

        int indice = random.Next(datos.Count);

        PokemonJson pokemonSalvaje = datos[indice];

        Pokemon nuevo = new Pokemon(pokemonSalvaje);

        Capturar(nuevo);

    }
    */

    public void MostrarEquipo()
    {
        foreach (Pokemon pokemon in equipo)
        {
            pokemon.MostrarInformacion();
        }
    }

    public void MostrarInventario()
    {
        miInventario.MostrarDatos();
    }



}