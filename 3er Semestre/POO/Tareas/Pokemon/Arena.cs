using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

class Arena
{
    public void Enfrentar(Pokemon atacante, Pokemon defensor)
    {
        int daño = atacante.ataque;
        int aux = defensor.Vida;

        RecibirDano(defensor, daño);
        Console.WriteLine("==================================");
        Console.WriteLine($"= El atacante {atacante.nombre}, hizo un ataque al defensor {defensor.nombre}");
        Console.WriteLine($"= {defensor.nombre} tenia una vida inicial de {aux}");
        Console.WriteLine($"= Recibio el ataque de {atacante.nombre} el cual es {daño}");
        Console.WriteLine($"= Tras el ataque, el defensor {defensor.nombre} ahora tiene una vida de {defensor.Vida}");
        Console.WriteLine("==================================\n");


    }

    private void RecibirDano(Pokemon herido, int daño)
    {
        herido.Vida -= daño;
    }
}