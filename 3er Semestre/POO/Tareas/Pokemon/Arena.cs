using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Text.Json.Serialization;

class Arena
{
    
    public void Enfrentar(Pokemon atacante, Pokemon defensor)
    {
        while(atacante.Vida != 0 && defensor.Vida != 0)
        {
            atacante.Atacar(defensor);

            if (defensor.Vida == 0)
            {
                Console.WriteLine("==================================");
                Console.WriteLine($"= El defensor {defensor.nombre}, ha sido derrotado por {atacante.nombre}");
                Console.WriteLine("==================================\n");
                break;
            }

            defensor.Atacar(atacante);

            if (atacante.Vida == 0)
            {
                Console.WriteLine("==================================");
                Console.WriteLine($"= El atacante {atacante.nombre}, ha sido derrotado por {defensor.nombre}");
                Console.WriteLine("==================================\n");

                break;
            }
        }

        

        
        




        /*
        int daño = atacante.ataque;
        int aux = defensor.Vida;

        RecibirDano(defensor, daño);
        Console.WriteLine("==================================");
        Console.WriteLine($"= El atacante {atacante.nombre}, hizo un ataque al defensor {defensor.nombre}");
        Console.WriteLine($"= {defensor.nombre} tenia una vida inicial de {aux}");
        Console.WriteLine($"= Recibio el ataque de {atacante.nombre} el cual es {daño}");
        Console.WriteLine($"= Tras el ataque, el defensor {defensor.nombre} ahora tiene una vida de {defensor.Vida}");
        Console.WriteLine("==================================\n");

        
        Console.WriteLine($"= Por ser un pokemon de agua, el pokemon atacante {this.nombre}, se curo la cantidad de {curacionAgua} ");
        Console.WriteLine($"= Se curo a su vida de {auxV}, y ahora tiene {this.Vida}");
        */

    }



    /*
    private void RecibirDano(Pokemon herido, int daño)
    {
        herido.Vida -= daño;
    }
    */
    
}